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
			this.isSettings = isSettings;
			this.languagesListView.ItemsSource = LanguagesService.instance.Data;
		}

		public SelectLanguagePage () 
			:this(false)
		{
			
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

