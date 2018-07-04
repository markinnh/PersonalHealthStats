using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PersonalHealthStats.Interfaces;

namespace PersonalHealthStats.ViewModels
{
    public class BrowseEntryViewModel:BaseViewModel
    {
       
        public BrowseEntryViewModel()
        {
            // bind to the collection changed event
            Items = TestData.MyData.EntryOwner.BloodSugarEntries;
        }
        /*
        private void BloodSugarEntries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var added = false;
            foreach (var item in e.NewItems)
            {
                if(item is Models.BloodSugarEntry entry)
                {
                    var newStat = ChangeToBloodSugarStats(entry);
                    if (newStat != null) { 
                        Items.Add(newStat);
                        added = true;
                    }
                }
            }
            if (added)
                NotifyPropertyChanged(nameof(Items));
                
        }
        */


        public ObservableCollection<Models.BloodSugarEntry> Items { get; private set; }

        /*
        private IEnumerable<Models.BloodSugarStats> GetEntries()
        {
            foreach (var item in ownerViewModel.GetTestData().EntryOwner.BloodSugarEntries)
            {
                var stats = ChangeToBloodSugarStats(item);
                if(stats != null)
                {
                    //stats.CalcStats();
                     yield return stats;
                }
            }
        }

        private Models.BloodSugarStats ChangeToBloodSugarStats(Models.BloodSugarEntry bloodSugarEntry) {
            var newStats = new Models.BloodSugarStats(bloodSugarEntry);
            if (newStats != null)
                newStats.CalcStats();
            return newStats;
        }
        */
        protected override void InitDependencies()
        {
            base.InitDependencies();
            //throw new NotImplementedException();
        }

        protected override void UpdateDependencies(string PropertyName)
        {
            //throw new NotImplementedException();
        }
    }
}
