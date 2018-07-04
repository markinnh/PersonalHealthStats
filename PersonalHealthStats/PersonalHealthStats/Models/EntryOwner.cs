using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using SQLite;

namespace PersonalHealthStats.Models
{
    public enum AccountType
    {
        Owner,
        Testing
    }

    public enum EntryUnits
    {
        MilligramsPerDeciliter,
        MillimolesPerLiter
    }

    public class EntryOwner
    {
        [Ignore]
        internal static int InstanceCount { get; private set; } = 0;
        [Ignore]
        public bool Loading { get; set; }
        [Ignore]
        public bool IsModified { get; set; }
        [PrimaryKey, AutoIncrement]
        public int EntryOwnerID { get; set; }
        [MaxLength(Constants.MaxEntryOwnerLength)]
        public string OwnerName { get; set; } = string.Empty;
        public DateTime StatsLastUpdated { get; set; } = Constants.MinimumDate;
        public EntryUnits EntryUnits { get; set; } = EntryUnits.MilligramsPerDeciliter;
        //public AccountType AccountType { get; set; }
        [Ignore]
        public virtual ObservableCollection<BloodSugarEntry> BloodSugarEntries { get; set; }

        [Ignore]
        public ObservableCollection<BloodSugarStat> Stats { get; set; }

        public EntryOwner()
        {
            InstanceCount++;

            BloodSugarEntries = new ObservableCollection<BloodSugarEntry>();
            BloodSugarEntries.CollectionChanged += BloodSugarEntries_CollectionChanged;
            Stats = new ObservableCollection<BloodSugarStat>();
        }

        private void BloodSugarEntries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is BloodSugarEntry entry)
                    {
                        entry.CalcStats(EntryUnits);
                        if (!Loading)
                        {
                            var firstOfMonth = new DateTime(entry.EntryDateTime.Year, entry.EntryDateTime.Month, 1);
                            if (firstOfMonth > StatsLastUpdated)
                            {
                                var days = new TimeSpan(Constants.DaysToGetStatsFor, 0, 0, 0);
                                var stats = GetStats(firstOfMonth - days, firstOfMonth);
                                StatsLastUpdated = firstOfMonth;
                                if (stats.Item1 > 0 && stats.Item2 > 0)
                                {
                                    var newStatsEntry = new BloodSugarStat();
                                    newStatsEntry.StatDate = firstOfMonth;
                                    newStatsEntry.AverageBloodSugar = stats.Item1;
                                    newStatsEntry.AverageDeviation = stats.Item2;
                                    newStatsEntry.EntryOwnerID = EntryOwnerID;
                                    newStatsEntry.Owner = this;
                                    newStatsEntry.AverageAIC = ProjectMath.CalcA1C(this.EntryUnits, stats.Item1);
                                    Stats.Add(newStatsEntry);
                                }
                            }
                            IsModified = true;
                        } 
                    }
                }
            }
        }

        public void AddEntry(decimal BloodSugar, DateTime EntryDateTime, string TestType, string Meal)
        {
            var lookup = LookupEntry(EntryDateTime);

            if (lookup == null)
            {
                lookup = new BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwnerID,
                    Owner = this,
                    EntryValue = BloodSugar,
                    EntryDateTime = EntryDateTime,
                    EntryType = BloodSugarEntry.GetEntryTypeFromString(TestType),
                    Meal = Meal
                };
                lookup.CalcStats(this.EntryUnits);
                BloodSugarEntries.Add(lookup);

                // disabled for now Data.BloodSugarsDatabase.Database.InsertOrUpdateBloodSugarEntryAsync(lookup);
            }
            else
            {
                lookup.EntryType = BloodSugarEntry.GetEntryTypeFromString(TestType);
                lookup.EntryValue = BloodSugar;
                lookup.Meal = Meal;
                lookup.CalcStats(this.EntryUnits);
                if (EntryOwnerID == 0)
                    Data.HealthStats.Database.CreateOrUpdateEntryOwnerAsync(this);
                // disabled for now Data.BloodSugarsDatabase.Database.InsertOrUpdateBloodSugarEntryAsync(lookup);
            }


        }

        public BloodSugarEntry LookupEntry(DateTime EntryDateTime)
        {
            return BloodSugarEntries.Where(e => e.EntryDateTime == EntryDateTime).FirstOrDefault();
        }

        public (decimal, decimal) GetStats(DateTime startDate, DateTime endDate)
        {
            IEnumerable<decimal> vs = from BloodSugarEntry entry in BloodSugarEntries
                                      where entry.EntryDateTime >= startDate && entry.EntryDateTime <= endDate
                                      select entry.EntryValue;

            var average = (vs.Count() == 0) ? 0 : vs.Average();
            var stddev = (vs.Count() == 0) ? 0 : vs.AverageDeviation();
            return (average, stddev);
        }

        internal static string[] ReadableEntryAsNames()
        {
            return Enum.GetNames(typeof(EntryUnits));
        }

        internal static EntryUnits ReadableNameToValue(string value)
        {
            return (EntryUnits)Enum.Parse(typeof(EntryUnits), value);
        }
    }
}
