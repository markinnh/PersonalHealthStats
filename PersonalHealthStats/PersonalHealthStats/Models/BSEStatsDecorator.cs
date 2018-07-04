using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PersonalHealthStats.Models
{
    public partial class BloodSugarEntry
    {
        /***************************************************************************************************
        *   All of the properties in this file will have to be decorated with the IgnoreAttribute          *
        *   when migrating to database.  Current plans are to get the logic working, then migrate to       *
        *   SQLite datastore.                                                                              *
        ***************************************************************************************************/
        //public BloodSugarEntry Entry { get; set; }
        //const int daysToGetStatsFor = 60;
        [Ignore]
        public string Header { get => string.Format("Test on {0}", EntryDateTime); }
        [Ignore]
        public string FormattedLine1 { get => string.Format("Value {0}, {1}", EntryValue, EntryType); }
        [Ignore]
        public string FormattedLine2 { get => string.Format(" Average : {0:#.00}, STDDEV : {1:#.00}, Estimated A1C : {2:#.00}", RollingAverage, RollingAverageDeviation, A1C); }
        [Ignore]
        public decimal RollingAverage { get; protected set; }
        [Ignore]
        public decimal RollingAverageDeviation { get; protected set; }
        [Ignore]
        public decimal A1C { get; protected set; }


        public void CalcStats(EntryUnits entryAs)
        {
            var days = new TimeSpan(Constants.DaysToGetStatsFor, 0, 0, 0);

            var result = Owner?.GetStats(EntryDateTime - days, EntryDateTime);
            RollingAverage = (decimal)result?.Item1;
            RollingAverageDeviation = (decimal)result?.Item2;
            // will need to adjust this calculation based on using mmol or mgperdl
            A1C = ProjectMath.CalcA1C(entryAs, RollingAverage);
        }
    }
}
