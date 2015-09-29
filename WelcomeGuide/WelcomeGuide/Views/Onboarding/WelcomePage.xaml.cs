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
		}

		protected override void OnAppearing ()
		{
			LanguagesService.instance.Fetch ();
		}

		public void OnContinueClicked(object sender, EventArgs e) 
		{
			Navigation.PushAsync (new SelectLanguagePage ());
		}
	}
}

