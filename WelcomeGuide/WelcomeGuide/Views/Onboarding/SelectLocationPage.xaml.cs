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
			LocationService.instance.OnError += OnLocationsFetchError;
			LocationService.instance.FetchDataAsync ();
			activityIndicator.IsVisible = LocationService.instance.Fetching;
		}

		protected override void OnDisappearing ()
		{
			LocationService.instance.OnDataChanged -= OnLocationsDownloaded;
			LocationService.instance.OnError -= OnLocationsFetchError;
		}

		void OnLocationsDownloaded ()
		{
			locationsListView.ItemsSource = LocationService.instance.Data;
			activityIndicator.IsVisible = false;
		}

		void OnLocationsFetchError (Exception obj)
		{
			activityIndicator.IsVisible = false;
		}

		void OnLocationSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var location = (Location)e.SelectedItem;
			SettingsService.instance.Location = location.Name;
			SettingsService.instance.HasSeenOnboarding = true;
			CategoriesService.instance.FetchDataAsync ();
			Navigation.PopModalAsync ();

		}
	}
}

