//#define UseTestData
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats
{
    public partial class TestData
    {

        public static TestData MyData { get; } = new TestData();
        public Models.EntryOwner EntryOwner { get; set; }

        public TestData()
        {
            //EntryOwner.AccountType = Models.AccountType.Testing;
#if UseTestData
            genTestEntries();
#else
            var lookup = Data.HealthStats.Database.LookupEntryOwner("Mark");
            if (lookup == null)
            {
                EntryOwner = new Models.EntryOwner();
                EntryOwner.OwnerName = "Mark";
                SeedData();  // uncomment the start of this line after generating the initialization code
                var setting = Data.HealthStats.Database.LookupSetting(Constants.TestDataStored);
                if (setting == null)
                {
                    Data.HealthStats.Database.CreateOrUpdateEntryOwnerAsync(EntryOwner);
                    var newSetting = new Models.StoredSetting() { SettingName = Constants.TestDataStored, SettingValue = "true" };
                    //Data.BloodSugarsDatabase.Database.
                }
                else if (setting == false)
                {
                    Data.HealthStats.Database.CreateOrUpdateEntryOwnerAsync(EntryOwner);
                }
            }
            else
                EntryOwner = lookup;
#endif

        }
#if UseTestData

        private void genTestEntries()
        {
            TimeSpan eightyNineDays = new TimeSpan(89, 0, 0, 0);
            TimeSpan breakfastTime = new TimeSpan(6, 0, 0);
            TimeSpan lunchTime = new TimeSpan(12, 0, 0);
            TimeSpan dinnerTime = new TimeSpan(19, 0, 0);
            //TimeSpan sevenHours = new TimeSpan(7, 0, 0);
            //TimeSpan fiveHours = new TimeSpan(5, 0, 0);
            TimeSpan twoHours = new TimeSpan(2, 0, 0);
            TimeSpan oneDay = new TimeSpan(24, 0, 0);

            var loopcount = 0;
            var randomGenerator = new Random(DateTime.Now.Millisecond);

            var startDate = DateTime.Now.Date - eightyNineDays;
            do
            {
                // first do the morning records
                var beforeBreakfast = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryType = Models.EntryType.BeforeBreakfast,
                    EntryDateTime = startDate + breakfastTime,
                    EntryValue = (short)randomGenerator.Next(70, 200),
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(beforeBreakfast);

                var afterBreakfast = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryType = Models.EntryType.AfterBreakfast,
                    EntryDateTime = beforeBreakfast.EntryDateTime + twoHours,
                    EntryValue = (short)randomGenerator.Next(130, 200),
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(afterBreakfast);

                // now do the lunch records
                var beforeLunch = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryDateTime = startDate + lunchTime,
                    EntryValue = (short)randomGenerator.Next(70, 200),
                    EntryType = Models.EntryType.BeforeLunch,
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(beforeLunch);

                var afterLunch = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryDateTime = beforeLunch.EntryDateTime + twoHours,
                    EntryType = Models.EntryType.AfterLunch,
                    EntryValue = (short)randomGenerator.Next(100, 200),
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(afterLunch);
                // last is the dinner records
                var beforeDinner = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryDateTime = startDate + dinnerTime,
                    EntryType = Models.EntryType.BeforeDinner,
                    EntryValue = (short)randomGenerator.Next(70, 200),
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(beforeDinner);
                var afterDinner = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryDateTime = beforeDinner.EntryDateTime + twoHours,
                    EntryType = Models.EntryType.AfterDinner,
                    EntryValue = (short)randomGenerator.Next(100, 200),
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(afterDinner);

                // before bed entry
                var beforeBed = new Models.BloodSugarEntry()
                {
                    EntryOwnerID = EntryOwner.EntryOwnerID,
                    EntryDateTime = afterDinner.EntryDateTime + twoHours,
                    EntryType = Models.EntryType.BeforeBed,
                    EntryValue = (short)randomGenerator.Next(110, 200),
                    Owner = EntryOwner
                };
                EntryOwner.BloodSugarEntries.Add(beforeBed);
                startDate += oneDay;
                loopcount++;
            } while (startDate < DateTime.Now.Date && loopcount < 100);
            //throw new NotImplementedException();
        }
#endif
    }

}
