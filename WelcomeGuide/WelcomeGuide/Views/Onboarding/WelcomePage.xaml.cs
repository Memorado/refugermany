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

			StartHeartbeat ();
		}

		protected override void OnAppearing ()
		{
			LanguagesService.instance.FetchDataAsync ();
		}

		public void OnContinueClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new SelectLanguagePage ());
		}

		public enum HeartState
		{
			Collapsed,
			Expanded
		}

		private HeartState _heartState = HeartState.Collapsed;

		public async void StartHeartbeat()
		{
			if (_heartState == HeartState.Collapsed) {
				await heartImage.ScaleTo (1.1, 700, Easing.BounceOut);
				_heartState = HeartState.Expanded;
			} else {
				await heartImage.ScaleTo (1.0, 700);
				_heartState = HeartState.Collapsed;
			}

			StartHeartbeat ();
		}
	}
}
