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
                case Constants.BeforeBreakfast:
                    result = EntryType.BeforeBreakfast;
                    break;
                case Constants.AfterBreakfast:
                    result = EntryType.AfterBreakfast;
                    break;
                case Constants.BeforeLunch:
                    result = EntryType.BeforeLunch;
                    break;
                case Constants.AfterLunch:
                    result = EntryType.AfterLunch;
                    break;
                case Constants.BeforeDinner:
                    result = EntryType.BeforeDinner;
                    break;
                case Constants.AfterDinner:
                    result = EntryType.AfterDinner;
                    break;
                case Constants.BeforeBed:
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
                    result = Constants.BeforeBreakfast;
                    break;
                case EntryType.AfterBreakfast:
                    result = Constants.AfterBreakfast;
                    break;
                case EntryType.BeforeLunch:
                    result = Constants.BeforeLunch;
                    break;
                case EntryType.AfterLunch:
                    result = Constants.AfterLunch;
                    break;
                case EntryType.BeforeDinner:
                    result = Constants.BeforeDinner;
                    break;
                case EntryType.AfterDinner:
                    result = Constants.AfterDinner;
                    break;
                case EntryType.BeforeBed:
                    result = Constants.BeforeBed;
                    break;
                default:
                    break;
            }

            return result;
        }
        internal static string[] GetTestTypeNames()
        {
            return new string[] { Constants.BeforeBreakfast, Constants.AfterBreakfast, Constants.BeforeLunch, Constants.AfterLunch, Constants.BeforeDinner, Constants.AfterDinner, Constants.BeforeBed };
        }
    }
}
