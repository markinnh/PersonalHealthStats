#define PREPOPULATE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalHealthStats.Models;

namespace PersonalHealthStats
{

public partial class TestData
{
	protected void SeedData()
	{
#if PREPOPULATE
		BloodSugarEntry[] entries = new BloodSugarEntry[]{new BloodSugarEntry(){
	EntryDateTime = new DateTime(636608359800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 248,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636609234600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 169,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636610071000000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 162,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636610933800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 155,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636611803800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 149,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636612667200000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 136,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636613546800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 138,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636615272400000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 146,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636615795000000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 131,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636616134000000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 141,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636616674600000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 116,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636616996800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 105,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636617520000000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 117,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636617848200000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 131,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636618394200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 134,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636618716400000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 124,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636619583400000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 130,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636620465400000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 111,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636621000000000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 157,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636621301800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 130,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636621859200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 171,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636622197600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 127,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636622726800000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 186,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636623052000000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 129,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636623587800000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 132,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636623901000000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 143,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636624443400000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 128,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636624773400000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 119,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636625300800000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 144,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636625624200000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 124,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636626500200000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 117,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636627025200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 126,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636627357600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 116,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636627888600000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 118,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636628221600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 131,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636628760400000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 121,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636629109600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 132,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636629622600000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 108,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636629953200000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 116,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636630493800000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 117,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636630819600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 137,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636631357200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 156,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636631669200000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 137,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636632222400000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 143,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636632536800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 140,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636633072000000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 213,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636633403800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 89,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636641197800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 126,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636641716200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 112,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636643765800000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 131,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636644329200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 139,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636647243400000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 126,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636647765400000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 202,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636653274600000000),
	EntryType = EntryType.BeforeBreakfast,
	EntryValue = 136,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
},
new BloodSugarEntry(){
	EntryDateTime = new DateTime(636653824200000000),
	EntryType = EntryType.AfterDinner,
	EntryValue = 130,
	EntryOwnerID = EntryOwner.EntryOwnerID,
	Owner = EntryOwner
}};
		foreach(var item in entries)
		{
			EntryOwner.BloodSugarEntries.Add(item);
		}
#endif

	}
}

}