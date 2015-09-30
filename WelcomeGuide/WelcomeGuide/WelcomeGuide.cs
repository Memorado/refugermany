using System;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage( new CategoryListPage () );
			if (!SettingsService.instance.HasSeenOnboarding) {
				MainPage.Navigation.PushModalAsync (new NavigationPage (new WelcomePage ()));
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			if (SettingsService.instance.HasSeenOnboarding) {
				CategoriesService.instance.FetchDataAsync ();
			}
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			if (SettingsService.instance.HasSeenOnboarding) {
				CategoriesService.instance.FetchDataAsync ();
			}
			// Handle when your app resumes
		}
	}
}

