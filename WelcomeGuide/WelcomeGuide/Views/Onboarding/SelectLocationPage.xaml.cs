using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class SelectLocationPage : ContentPage
	{
		public SelectLocationPage ()
		{
			InitializeComponent ();
			OnLocationsDownloaded ();
		}

		protected override void OnAppearing ()
		{
			LocationService.instance.OnDataChanged += OnLocationsDownloaded;
		}

		protected override void OnDisappearing ()
		{
			LocationService.instance.OnDataChanged -= OnLocationsDownloaded;
		}

		void OnLocationsDownloaded ()
		{
			locationsListView.ItemsSource = LocationService.instance.Data;
		}

		void OnLocationSelected(object sender, SelectedItemChangedEventArgs e) 
		{
			CategoriesService.instance.FetchDataAsync ();
			var location = (Location)e.SelectedItem;
			SettingsService.instance.Location = location.Name;
			SettingsService.instance.HasSeenOnboarding = true;

			Navigation.PushAsync (new CategoryListPage ());
		}
	}
}

