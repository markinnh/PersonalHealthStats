using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PersonalHealthStats.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public ObservableCollection<Models.BloodSugarStat> Items { get; set; }

        public StatsViewModel()
        {
            Items = TestData.MyData.EntryOwner.Stats;
        }
    }
}
