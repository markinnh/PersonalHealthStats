using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalHealthStats.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalHealthStats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public MasterDetailPage1()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MessagingCenter.Subscribe<BrowseEntryPage, Models.BloodSugarEntry>(this, Constants.SelectedEntryMessage, (sender, arg) => SelectedEntry(arg));

        }

        private void SelectedEntry(BloodSugarEntry arg)
        {
            var page = (CreateEntryPage)Activator.CreateInstance(typeof(CreateEntryPage));
            page.Title = "Edit Entry";
            Detail = new NavigationPage(page);
            if (page.BindingContext is ViewModels.CreateEntryViewModel vm)
            {
                vm.Entry = arg;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterDetailPage1MenuItem item)
            {

                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;

                Detail = new NavigationPage(page);
                IsPresented = false;

                MasterPage.ListView.SelectedItem = null;
            }
        }
    }
}