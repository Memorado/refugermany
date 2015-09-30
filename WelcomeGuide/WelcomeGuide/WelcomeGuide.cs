using System;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public class ThemedNavigationPage : NavigationPage
	{
		public ThemedNavigationPage (Page root)
			: base (root)
		{
			BarBackgroundColor = Color.FromHex ("4AC3BE");
			BarTextColor = Color.FromHex ("F6F1F1");
		}
	}

	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ThemedNavigationPage (new CategoryListPage ());
//
//			if (!SettingsService.instance.HasSeenOnboarding) {
				MainPage.Navigation.PushModalAsync (
					new ThemedNavigationPage (new WelcomePage ()) 
				);
//			}
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

