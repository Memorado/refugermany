namespace WelcomeGuide.Droid
{
	using System;
	using Android.App;
	using Android.Net;
	using Android.OS;
	using Android.Widget;

	public class AndroidReachabilityService : IReachabilityService
	{
		public static AndroidReachabilityService Instance { get; set; }

		private ConnectivityManager _connectivityManager;

		public AndroidReachabilityService (ConnectivityManager connectivityManager)
		{
			this._connectivityManager = connectivityManager; //(ConnectivityManager)GetSystemService (ConnectivityService);
		}

		#region IReachabilityService implementation

		public bool IsNetworkReachable {
			get {
				var activeConnection = _connectivityManager.ActiveNetworkInfo;

				if ((activeConnection != null) && activeConnection.IsConnected)
				{
					// we are connected to a network.
					return true;
				}
				return false;
			}
		}

		#endregion
	}
}

