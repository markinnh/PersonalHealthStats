using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats.Models
{
    public class BloodSugarStat
    {
        [SQLite.PrimaryKey,SQLite.AutoIncrement]
        public int BloodSugarStatID { get; set; }
        [SQLite.Indexed]
        public DateTime StatDate { get; set; }
        public decimal AverageBloodSugar { get; set; }
        public decimal AverageDeviation { get; set; }
        public decimal AverageAIC { get; set; }
        public int EntryOwnerID { get; set; }
        [SQLite.Ignore]
        public EntryOwner Owner { get; set; }

        [SQLite.Ignore]
        public string Text { get => string.Format("Stat Date {0:MMM-yyyy}, Estimated AIC {1:#.00}", StatDate, AverageAIC); }
        [SQLite.Ignore]
        public string Detail { get => string.Format("Average {0:#.00}, StandardDeviation {1:#.00}", AverageBloodSugar, AverageDeviation); }
    }
}
