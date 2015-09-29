using System;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			ContentPage firstPage;
			if (SettingsService.instance.HasSeenOnboarding) {
				firstPage = new CategoryListPage ();
			} else {
				firstPage = new WelcomePage ();
			}
			MainPage = new NavigationPage( firstPage );

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

