using System;

namespace WelcomeGuide
{
	public interface IReachabilityService
	{
		bool IsNetworkReachable {get;}
	}

	public class ReachabilityService
	{
		private static IReachabilityService _instance;

		public static IReachabilityService instance {
			get {
				if (_instance == null) {
					#if __IOS__
					_instance = new WelcomeGuide.iOS.iOSReachabilityService();
					#else
					_instance = new WelcomeGuide.Droid.AndroidReachabilityService();
					#endif
				}

				return _instance;
			}
		}
	}
}

