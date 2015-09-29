using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WelcomeGuide
{
	public class LanguagesService : BackendService<List<Language>>
	{
		// Singleton
		private static LanguagesService _instance;

		public static LanguagesService instance {
			get {
				if (_instance == null) {
					_instance = new LanguagesService ();
				}
				return _instance;
			}
		}

		public LanguagesService () :
			base ("/languages", "languages.json", CachedResponse.Languages)
		{
			
		}
	}
}

