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
			NavigationPage.SetHasNavigationBar (this, false);

			#if __IOS__
			continueButton.Image = "Button.png";
			#else
			continueButton.Text = "Continue";
			continueButton.TextColor = Color.FromHex ("F6F1F1");
			#endif
		}

		protected override void OnAppearing ()
		{
			LanguagesService.instance.FetchDataAsync ();
		}

		public void OnContinueClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new SelectLanguagePage ());
		}
	}
}
