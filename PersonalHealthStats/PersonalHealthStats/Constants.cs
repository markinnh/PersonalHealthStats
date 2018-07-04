using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats
{
    internal class Constants
    {
        /// <summary>
        /// Start at the beginning of 2017 for data entry
        /// </summary>
        internal static readonly DateTime MinimumDate = new DateTime(2017, 1, 1);
        /// <summary>
        /// By the 23rd century they should have cured diabetes and blood pressure
        /// </summary>
        internal static readonly DateTime MaximumDate = new DateTime(2300, 12, 31);

        internal const string DbFilename = "BloodSugarData.db";

        internal const string MilliMole = "mmole";

        internal const string MgPerDl = "mg/dl";

        internal const decimal ConvertFrommmole = 18.0182m;

        /// <summary>
        /// String Length limiter constants
        /// </summary>
        internal const int MaxMealLength = 250;
        internal const int MaxEntryOwnerLength = 50;
        internal const int MaxSettingLength = 250;

        internal const int DaysToGetStatsFor = 60;
        internal const int DaysToSaveBloodSugarEntries = 150;
        internal const int DaysToSaveBloodSugarStats = 365;

        /// <summary>
        /// Messaging to pass data between viewmodels and from viewmodels to views
        /// </summary>
        internal const string SelectedEntryMessage = "SelectedEntry";
        internal const string DoMessage = "DoMessage";
        internal const string DoMessageResult = "DoMessageResult";

        /// <summary>
        /// SettingNames to be stored in the database
        /// </summary>
        internal const string TestDataStored = "TestDataStored";
        internal const string ActiveOwnerName = "ActiveOwnerName";
    }
}
