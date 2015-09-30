using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	

	public partial class SettingsPage : ContentPage
	{
		
		public class Setting {
			public String Title { get; set; }
			public Action Action { get; set; }
		}

		public SettingsPage ()
		{
			InitializeComponent ();

			myListView.ItemsSource = new List<Setting> () {
				new Setting () { Title = "Change Language", Action = () => { Navigation.PushAsync( new SelectLanguagePage()); }  },
				new Setting () { Title = "Change Location", Action = () => { Navigation.PushAsync( new SelectLocationPage()); }  }
			};


		}

		public void OnListItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			Action action = ((Setting)e.SelectedItem).Action;
			action ();

		}
	}
}

