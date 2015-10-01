using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class SelectLocationPage : ContentPage
	{
		Boolean isSetting { set; get; }

		public SelectLocationPage (Boolean isSetting)
		{
			InitializeComponent ();
			this.isSetting = isSetting;
			this.locationsListView.ItemsSource = LocationService.instance.Data;
		}

		public SelectLocationPage ()
			: this (false)
		{
			
		}

		void OnLocationSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				var location = (Location)e.SelectedItem;
				SettingsService.instance.Location = location.Name;
				SettingsService.instance.HasSeenOnboarding = true;
				CategoriesService.instance.FetchDataAsync ();
				if (isSetting == true) {
					Navigation.PopAsync ();
				} else {
					Navigation.PopModalAsync ();
				}
				locationsListView.SelectedItem = null;
			}
		}
	}
}

