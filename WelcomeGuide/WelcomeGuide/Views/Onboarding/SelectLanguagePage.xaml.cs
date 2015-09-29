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
		}

		protected override void OnDisappearing ()
		{
			LanguagesService.instance.OnDataChanged -= OnLanguagesDownloaded;
		}

		void OnLanguagesDownloaded ()
		{
			languagesListView.ItemsSource = LanguagesService.instance.Data;
		}

		void OnLanguageSelected(object sender, SelectedItemChangedEventArgs e) 
		{
			CategoriesService.instance.FetchDataAsync ();
			var language = (Language)e.SelectedItem;
			SettingsService.instance.Language = language.Code;
			Navigation.PushAsync (new CategoryListPage ());
		}
	}
}

