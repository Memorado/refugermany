using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;

namespace WelcomeGuide.Droid
{
	[Activity (Theme = "@android:style/Theme.Holo.Light", ScreenOrientation = ScreenOrientation.Portrait, Label = "Refugermany", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			var connectivityManager = (ConnectivityManager)GetSystemService (Context.ConnectivityService);
			AndroidReachabilityService.Instance = new AndroidReachabilityService (connectivityManager);

			LoadApplication (new App ());
		}
	}
}

