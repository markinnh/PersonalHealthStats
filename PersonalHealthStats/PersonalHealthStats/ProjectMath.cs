using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats
{
    internal class ProjectMath
    {
        internal static decimal CalcA1C(Models.EntryUnits entryAs,decimal bloodSugar)
        {
            if (entryAs == Models.EntryUnits.MilligramsPerDeciliter)
                return (bloodSugar + 46.7m) / 28.7m;
            else
                return ((bloodSugar * Constants.ConvertFrommmole) + 46.7m) / 28.7m;

        }
    }
}
