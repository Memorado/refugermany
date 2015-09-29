using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace WelcomeGuide
{
	public class ArticlesService
	{
		// Singleton
		private static ArticlesService _instance;
		public static ArticlesService instance {
			get {
				if (_instance == null) {
					_instance = new ArticlesService ();
				}
				return _instance;
			}
		}

		private const String API_ADDRESS = "http://192.168.2.68:3000/";
		private List<Category> cachedArticles;

		public event Action OnArticlesUpdated;
		public List<Category> Categories { get; private set; }
			
		private ArticlesService ()
		{
			#if __IOS__
			var resourcePrefix = "WelcomeGuide.iOS.Resources.";
			#endif
			#if __ANDROID__
			var resourcePrefix = "WelcomeGuide.Droid.Resources.";
			#endif

			var assembly = typeof(ArticlesService).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (resourcePrefix + "categories.json");
			StreamReader sr = new StreamReader (stream);
			String contents = sr.ReadToEnd ();
			this.Categories = parseJson (contents);
		}

		private List<Category> parseJson(String jsonContents)
		{
			var parsed = JsonConvert.DeserializeObject<List<Category>> (jsonContents);
			return parsed;
		}

	}
}

