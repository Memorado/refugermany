using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
			BackgroundColor = Color.FromHex ("4AC3BE");
		}

		protected override void OnAppearing ()
		{
			LanguagesService.instance.FetchDataAsync ();
		}

		public void OnContinueClicked(object sender, EventArgs e) 
		{
			Navigation.PushAsync (new SelectLanguagePage ());
		}
	}
}

