using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalHealthStats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage ()
        {
            InitializeComponent();

            Children.Add(new BrowseEntryPage());
            
            Children.Add(new CreateEntryPage());

            Children.Add(new Pages.StatsPage());

            Children.Add(new Pages.UsersPage());
            Children.Add(new Pages.SettingsPage());
        }
    }
}