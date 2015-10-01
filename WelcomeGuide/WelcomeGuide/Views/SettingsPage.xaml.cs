using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	

	public partial class SettingsPage : ContentPage
	{
		
		public class Setting {
			public String Title { get; set; }
			public String Detail { get; set; }
			public Action Action { get; set; }
		}

		public SettingsPage ()
		{
			InitializeComponent ();
			fillData ();
		}

		protected override void OnAppearing ()
		{
			fillData ();
		}

		public void fillData () {
			myListView.ItemsSource = new List<Setting> () {
				new Setting () { Title = "Change Language", Detail = SettingsService.instance.LanguageName, Action = () => { Navigation.PushAsync( new SelectLanguagePage(true)); }  },
				new Setting () { Title = "Change Location", Detail = SettingsService.instance.Location, Action =  () => { Navigation.PushAsync( new SelectLocationPage(true)); }  }
			};
		}

		public void OnListItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				Action action = ((Setting)e.SelectedItem).Action;
				action ();
				myListView.SelectedItem = null;
			}
		}
	}
}

