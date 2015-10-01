using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class SelectLanguagePage : ContentPage
	{
		Boolean isSettings { set; get; }

		public SelectLanguagePage (Boolean isSettings)
		{
			InitializeComponent ();
			OnLanguagesDownloaded ();
			this.isSettings = isSettings;
		}

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

		void OnLanguageSelected (object sender, SelectedItemChangedEventArgs e)
		{	
			if (e.SelectedItem != null) {
				var language = (Language)e.SelectedItem;
				SettingsService.instance.Language = language.Code;
				SettingsService.instance.LanguageName = language.Name;
				LocationService.instance.FetchDataAsync ();
				CategoriesService.instance.FetchDataAsync ();
				if (isSettings == true) {
					Navigation.PopAsync ();
				} else {
					Navigation.PushAsync (new SelectLocationPage ());
				}
				languagesListView.SelectedItem = null;
			} 
		}
	}
}

