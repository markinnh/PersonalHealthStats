using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PersonalHealthStats.Models
{
    public enum EntryType
    {
        BeforeBreakfast,
        AfterBreakfast,
        BeforeLunch,
        AfterLunch,
        BeforeDinner,
        AfterDinner,
        BeforeBed  }

    public partial class BloodSugarEntry
    {
        //const int daysToGetStatsFor = 60;
        const string beforeBreakfast = "Before Breakfast";
        const string afterBreakfast = "After Breakfast";
        const string beforeLunch = "Before Lunch";
        const string afterLunch = "After Lunch";
        const string beforeDinner = "Before Dinner";
        const string afterDinner = "After Dinner";
        const string beforeBed = "Before Bed";

        [PrimaryKey,AutoIncrement]
        public int BloodSugarEntryID { get; set; }
        [Indexed]
        public DateTime EntryDateTime { get; set; }
        public EntryType EntryType { get; set; }
        public decimal EntryValue { get; set; }
        [MaxLength(Constants.MaxMealLength)]
        public string Meal { get; set; } = string.Empty;
        public int EntryOwnerID { get; set; }
        [Ignore]
        public virtual EntryOwner Owner { get; set; }
        [Ignore]
        internal static int InstanceCount { get; set; } = 0;

        public BloodSugarEntry()
        {
            InstanceCount++;
        }

        internal static EntryType GetEntryTypeFromString(string target)
        {
            EntryType result = EntryType.BeforeBreakfast;

            switch (target)
            {
                case beforeBreakfast:
                    result = EntryType.BeforeBreakfast;
                    break;
                case afterBreakfast:
                    result = EntryType.AfterBreakfast;
                    break;
                case beforeLunch:
                    result = EntryType.BeforeLunch;
                    break;
                case afterLunch:
                    result = EntryType.AfterLunch;
                    break;
                case beforeDinner:
                    result = EntryType.BeforeDinner;
                    break;
                case afterDinner:
                    result = EntryType.AfterDinner;
                    break;
                case beforeBed:
                    result = EntryType.BeforeBed;
                    break;
                default:
                    break;
            }
            return result;
        }
        internal string GetReadableName()
        {
            return GetReadableTestTypeName(this.EntryType);
        }

        internal static string GetReadableTestTypeName(EntryType entryType)
        {
            string result = string.Empty;
            switch (entryType)
            {
                case EntryType.BeforeBreakfast:
                    result = beforeBreakfast;
                    break;
                case EntryType.AfterBreakfast:
                    result = afterBreakfast;
                    break;
                case EntryType.BeforeLunch:
                    result = beforeLunch;
                    break;
                case EntryType.AfterLunch:
                    result = afterLunch;
                    break;
                case EntryType.BeforeDinner:
                    result = beforeDinner;
                    break;
                case EntryType.AfterDinner:
                    result = afterDinner;
                    break;
                case EntryType.BeforeBed:
                    result = beforeBed;
                    break;
                default:
                    break;
            }

            return result;
        }
        internal static string[] GetTestTypeNames()
        {
            return new string[] { beforeBreakfast, afterBreakfast, beforeLunch, afterLunch, beforeDinner, afterDinner, beforeBed };
        }
    }
}
