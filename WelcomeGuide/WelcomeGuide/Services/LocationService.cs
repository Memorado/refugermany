using System;
using System.Collections.Generic;

namespace WelcomeGuide
{
	public class LocationService : BackendService<List<Location>>
	{
		// Singleton
		private static LocationService _instance;

		public static LocationService instance {
			get {
				if (_instance == null) {
					_instance = new LocationService ();
				}
				return _instance;
			}
		}

		private LocationService() :
			base("/locations", "locations.json", CachedResponse.Locations)
		{
			
		}
	}
}

