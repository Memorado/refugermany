using System;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage( new CategoryListPage () )
			{
				Tint = Color.FromHex("4AC3BE"),
				BarBackgroundColor = Color.FromHex("4AC3BE"),
				BarTextColor = Color.Black
			};

			if (!SettingsService.instance.HasSeenOnboarding) {
				MainPage.Navigation.PushModalAsync (
					new NavigationPage (
						new WelcomePage ()
					) {
						Tint = Color.FromHex("4AC3BE"),
						BarBackgroundColor = Color.FromHex("4AC3BE"),
						BarTextColor = Color.Black
					}
				);
			}

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

