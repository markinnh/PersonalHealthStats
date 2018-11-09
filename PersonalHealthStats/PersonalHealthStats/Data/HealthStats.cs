using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using System.Diagnostics;
using PersonalHealthStats.Models;

namespace PersonalHealthStats.Data
{
    /// <summary>
    /// Stores blood sugar entries, owner info, and stats for the database
    /// </summary>
    internal partial class HealthStats
    {
        static HealthStats database;
        internal static HealthStats Database
        {
            get
            {
                if (database == null)
                    database = new HealthStats(DependencyService.Get<Interfaces.IFileHelper>().GetLocalFileLocation(Constants.DbFilename));
                return database;
            }
        }

        internal static bool ResettingTables { get; set; } = Constants.ResetTables;
        internal static bool Initialized { get; set; } = false;

        protected SQLiteAsyncConnection Connection { get; set; }

        internal HealthStats(string PathAndFile)
        {
            Connection = new SQLiteAsyncConnection(PathAndFile);

            if (ResettingTables)
            {
                Connection.DropTableAsync<Models.BloodSugarEntry>().Wait();
                Connection.DropTableAsync<Models.EntryOwner>().Wait();
                Connection.DropTableAsync<Models.StoredSetting>().Wait();
            }

            Connection.CreateTableAsync<Models.BloodSugarEntry>().Wait();
            Connection.CreateTableAsync<Models.EntryOwner>().Wait();
            Connection.CreateTableAsync<Models.StoredSetting>().Wait();
            Connection.CreateTableAsync<Models.BloodSugarStat>().Wait();
            Initialized = true;
        }
        ~HealthStats()
        {
            if (Connection != null)
                Connection = null;
        }

        #region Routines for BloodSugarEntries
        /// <summary>
        /// returns an entire collection of entries from the database, should not be used except in the purge old entries routine 
        /// since the entries are linked to the entryowner class 
        /// </summary>
        /// <returns>a list of all the blood sugar entries in the database</returns>
        internal Task<List<Models.BloodSugarEntry>> GetBloodSugarEntriesAsync()
        {
            return Connection.Table<Models.BloodSugarEntry>().ToListAsync();
        }
        /// <summary>
        /// links a collection of BloodSugarEntries to an EntryOwner object
        /// </summary>
        /// <param name="entryOwner">entryOwner to collection information for</param>
        internal async void GetChildEntriesAsync(Models.EntryOwner entryOwner)
        {
            entryOwner.Loading = true;
            List<Models.BloodSugarEntry> childEntries = await Connection.Table<Models.BloodSugarEntry>().Where(e => e.EntryOwnerID == entryOwner.EntryOwnerID).ToListAsync();

            if (childEntries == null)
                Debug.WriteLine("No records returned from Query.");
            else
                Debug.WriteLine("{0} records returned from blood sugar entries query for {1}", childEntries.Count, entryOwner.OwnerName);

            foreach (var entry in childEntries)
            {
                entry.Owner = entryOwner;
                entryOwner.BloodSugarEntries.Add(entry);
            }
            entryOwner.Loading = false;
        }

        internal Task<int> CreateOrUpdateBloodSugarEntryAsync(Models.BloodSugarEntry entry)
        {
            if (entry.BloodSugarEntryID != 0)
            {
                return Connection.UpdateAsync(entry);
            }
            else
                return Connection.InsertAsync(entry);
        }


        internal Task<int> DeleteBloodSugarEntry(Models.BloodSugarEntry entry)
        {
            return Connection.DeleteAsync(entry);
        }

        /// <summary>
        /// Purge outdated entries from the database, currently anything older than 180 days is removed from the database
        /// </summary>
        internal async void DeleteOldEntriesAsync()
        {
            DateTime date = DateTime.Today;
            TimeSpan span = new TimeSpan(Constants.DaysToSaveBloodSugarEntries, 0, 0, 0);
            DateTime cutoff = DateTime.Today - span;

            List<Models.BloodSugarEntry> entries = await Connection.Table<BloodSugarEntry>().
                Where(bse => bse.EntryDateTime < cutoff).ToListAsync();


            foreach (var item in entries)
            {
                int x = await DeleteBloodSugarEntry(item);
            }
        }
        #endregion

        #region Routines for EntryOwner
        internal Task<List<Models.EntryOwner>> GetEntryOwnersAsync()
        {
            return Connection.Table<Models.EntryOwner>().ToListAsync();
        }

        internal Models.EntryOwner LookupEntryOwner(string LookupOwnerName)
        {
            var result = Connection.Table<Models.EntryOwner>().Where(eo => eo.OwnerName == LookupOwnerName).ToListAsync();
            var lookup = result.Result.FirstOrDefault();
            if (lookup != null)
            {
                GetChildEntriesAsync(lookup);
                GetChildStats(lookup);
            }
            return lookup;
        }

        internal async void CreateOrUpdateEntryOwnerAsync(Models.EntryOwner entryOwner)
        {

            if (entryOwner.EntryOwnerID != 0)
            {
                var result = await Connection.UpdateAsync(entryOwner);
            }
            else
            {

                // if an entry with the same name exist, don't add it again.
                var potentialExisting = LookupEntryOwner(entryOwner.OwnerName);
                if (potentialExisting?.OwnerName != entryOwner.OwnerName)
                {
                    var result = Connection.InsertAsync(entryOwner);
                    var lookup = LookupEntryOwner(entryOwner.OwnerName);
                    if (lookup?.EntryOwnerID > 0)
                        entryOwner.EntryOwnerID = lookup.EntryOwnerID;
                }
                else
                {
                    entryOwner = potentialExisting;
                    return;
                }
            }

            Debug.WriteLine(string.Format("EntryOwnerID {0} 0", entryOwner.EntryOwnerID == 0 ? "is" : "is not"), "Diagnostic");

            if (entryOwner.EntryOwnerID != 0)
            {
                foreach (var item in entryOwner.BloodSugarEntries)
                {
                    item.EntryOwnerID = entryOwner.EntryOwnerID;
                    var updateBloodSugarEntry = CreateOrUpdateBloodSugarEntryAsync(item);
                }
                foreach (var item in entryOwner.Stats)
                {
                    item.EntryOwnerID = entryOwner.EntryOwnerID;
                    var updateStatsEntry = CreateOrUpdateStats(item);
                }

            }
        }

        private void MergeRecords(EntryOwner entryOwner, EntryOwner potentialExisting)
        {
            foreach (var item in entryOwner.BloodSugarEntries)
            {
                var existing = potentialExisting.BloodSugarEntries.Where(entry => entry.EntryDateTime == item.EntryDateTime).FirstOrDefault();
                // if datetime does not exist in the database, add it to the database
                if (existing == null)
                {
                    CreateOrUpdateBloodSugarEntryAsync(item);
                }
            }
            //throw new NotImplementedException();
        }

        internal async void DeleteEntryOwner(Models.EntryOwner entryOwner)
        {
            await Connection.DeleteAsync(entryOwner);
        }

        #endregion

        #region Stats Routines
        internal Task<int> CreateOrUpdateStats(Models.BloodSugarStat stat)
        {
            if (stat.BloodSugarStatID != 0)
                return Connection.UpdateAsync(stat);
            else
                return Connection.InsertAsync(stat);
        }

        internal Task<List<Models.BloodSugarStat>> GetBloodSugarStats()
        {
            return Connection.Table<Models.BloodSugarStat>().ToListAsync();
        }

        internal void GetChildStats(Models.EntryOwner entryOwner)
        {
            var result = Connection.Table<Models.BloodSugarStat>().Where(stat => stat.EntryOwnerID == entryOwner.EntryOwnerID).ToListAsync();
            var childStats = result.Result;

            if (childStats == null)
            {
                Debug.WriteLine("No records returned in stat query for {0}", entryOwner.OwnerName);
            }
            else
                Debug.WriteLine("{0} records returned in stat query for {1}.", childStats.Count(), entryOwner.OwnerName);


            foreach (var item in childStats)
            {
                item.Owner = entryOwner;
                entryOwner.Stats.Add(item);
            }
        }

        internal Task<int> DeleteStat(Models.BloodSugarStat stat)
        {
            return Connection.DeleteAsync(stat);
        }

        internal async Task DeleteOldStats()
        {
            TimeSpan span = new TimeSpan(Constants.DaysToSaveBloodSugarStats, 0, 0, 0);
            DateTime cutoff = DateTime.Today - span;
            List<BloodSugarStat> oldStats = await Connection.Table<BloodSugarStat>().Where(stat => stat.StatDate < cutoff).ToListAsync();

            foreach (var item in oldStats)
            {
                await Connection.DeleteAsync(item);
            }
        }
        #endregion

        #region Routines for UserSettings stored in a database
        internal Task<List<Models.StoredSetting>> GetSettingsAsync()
        {
            return Connection.Table<Models.StoredSetting>().ToListAsync();
        }

        internal Task<int> CreateOrUpdateSettingAsync(Models.StoredSetting setting)
        {
            if (setting.StoredSettingID != 0)
            {
                return Connection.UpdateAsync(setting);
            }
            else
                return Connection.InsertAsync(setting);
        }

        internal Models.StoredSetting LookupSetting(string LookupName)
        {
            var taskList = Connection.Table<Models.StoredSetting>().Where(set => set.SettingName == LookupName).ToListAsync();
            return taskList.Result?.FirstOrDefault();
        }

        internal Task<int> DeleteSetting(Models.StoredSetting setting)
        {
            return Connection.DeleteAsync(setting);
        }
        #endregion
    }
}
