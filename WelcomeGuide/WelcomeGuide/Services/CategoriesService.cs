using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace WelcomeGuide
{
	public class CategoriesService
	{
		// Singleton
		private static CategoriesService _instance;
		public static CategoriesService instance {
			get {
				if (_instance == null) {
					_instance = new CategoriesService ();
				}
				return _instance;
			}
		}

		public event Action OnCategoriesUpdated;
		public List<Category> Categories { get; private set; }
			
		private CategoriesService ()
		{
			#if __IOS__
			var resourcePrefix = "WelcomeGuide.iOS.Resources.";
			#endif
			#if __ANDROID__
			var resourcePrefix = "WelcomeGuide.Droid.Resources.";
			#endif

			var assembly = typeof(CategoriesService).GetTypeInfo().Assembly;
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
			
		public void Fetch() 
		{
			string baseUrl = "https://refhelp.herokuapp.com:443/api/v1";
			FetchCategoriesAsync (baseUrl);
		}
			
		private async void FetchCategoriesAsync(string baseUrl)
		{
			string endpoint = "/categories";
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (baseUrl + endpoint));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ())
			{
				using (Stream stream = response.GetResponseStream ())
				{
					StreamReader sr = new StreamReader (stream);
					String contents = sr.ReadToEnd ();
					this.Categories = parseJson (contents);

					if (OnCategoriesUpdated != null) {
						OnCategoriesUpdated ();
					}
				}
			}
		}


	}
}

