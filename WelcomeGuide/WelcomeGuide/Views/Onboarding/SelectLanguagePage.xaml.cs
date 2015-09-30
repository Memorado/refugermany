using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class SelectLanguagePage : ContentPage
	{
		public SelectLanguagePage ()
		{
			InitializeComponent ();
			OnLanguagesDownloaded ();
		}

		protected override void OnAppearing ()
		{
			LanguagesService.instance.OnDataChanged += OnLanguagesDownloaded;
			LanguagesService.instance.OnError += OnLanguagesFetchError;
			LanguagesService.instance.FetchDataAsync ();
			activityIndicator.IsVisible = LanguagesService.instance.Fetching;
		}

		protected override void OnDisappearing ()
		{
			LanguagesService.instance.OnDataChanged -= OnLanguagesDownloaded;
			LanguagesService.instance.OnError -= OnLanguagesFetchError;
		}

		void OnLanguagesDownloaded ()
		{
			languagesListView.ItemsSource = LanguagesService.instance.Data;
			activityIndicator.IsVisible = false;
		}

		void OnLanguagesFetchError (Exception obj)
		{
			activityIndicator.IsVisible = false;
		}

		void OnLanguageSelected(object sender, SelectedItemChangedEventArgs e) 
		{
			var language = (Language)e.SelectedItem;
			SettingsService.instance.Language = language.Code;
			LocationService.instance.FetchDataAsync ();
			Navigation.PushAsync (new SelectLocationPage ());
		}
	}
}

