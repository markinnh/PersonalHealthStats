using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalHealthStats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseEntryPage : ContentPage
    {
        //public ObservableCollection<string> Items { get; set; }

        public BrowseEntryPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.BrowseEntryViewModel();
            //         Items = new ObservableCollection<string>
            //         {
            //             "Item 1",
            //             "Item 2",
            //             "Item 3",
            //             "Item 4",
            //             "Item 5"
            //         };

            //MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem is Models.BloodSugarEntry entry)
                {
                    MessagingCenter.Send(this, Constants.SelectedEntryMessage, entry);
                }
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                Debug.WriteLine($"Message {ex.Message}, InnerException {ex.InnerException.Message}");
            }
        }
    }
}
