using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PersonalHealthStats
{
	public partial class CreateEntryPage : ContentPage,Interfaces.IPageAlerter
	{
		public CreateEntryPage()
		{
			InitializeComponent();


            BindingContext = new ViewModels.CreateEntryViewModel();
            MessagingCenter.Subscribe<ViewModels.CreateEntryViewModel, Payload.OneOptionMessagePayload>(this, Constants.DoMessage, (sender, arg) => { DisplayAlert(arg.Title, arg.Message, arg.CancelText); });
            MessagingCenter.Subscribe<ViewModels.CreateEntryViewModel, Payload.TwoOptionMessagePayload>(this, Constants.DoMessage, (sender, arg) => { DisplayAlert(arg.Title, arg.Message, arg.CancelText, arg.OkText); });
		}

        public Task DoDisplayAlert(string AlertTitle, string AlertMessage, string Cancel)
        {
            return DisplayAlert(AlertTitle,AlertMessage,Cancel);
        }

        public Task DoDisplayAlert(string AlertTitle, string AlertMessage, string Accept, string Cancel)
        {
            return DisplayAlert(AlertTitle,AlertMessage,Accept,Cancel);
        }
    }
}
