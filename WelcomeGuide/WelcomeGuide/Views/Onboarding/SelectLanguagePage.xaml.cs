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
			LanguagesService.instance.OnLanguagesUpdated += OnLanguagesDownloaded;
		}

		protected override void OnDisappearing ()
		{
			LanguagesService.instance.OnLanguagesUpdated -= OnLanguagesDownloaded;
		}

		void OnLanguagesDownloaded ()
		{
			languagesListView.ItemsSource = LanguagesService.instance.Languages;
		}

		void OnLanguageSelected(object sender, SelectedItemChangedEventArgs e) 
		{
			CategoriesService.instance.Fetch ();
			var language = (Language)e.SelectedItem;
			SettingsService.instance.Language = language.Code;
			Navigation.PushAsync (new CategoryListPage ());
		}
	}
}

