using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WelcomeGuide
{
	public class LanguagesService
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

		public List<Language> Languages;
		public event Action OnLanguagesUpdated;

		public LanguagesService ()
		{
			var cachedResponse = CachingService.instance.GetCache (CachedResponse.Languages);
			if (cachedResponse == null) {
				createDefaultCache ();
			}
			this.Languages = parseFromCache ();
		}

		public void Fetch() 
		{
			string baseUrl = "https://refhelp.herokuapp.com:443/api/v1";
			FetchLanguagesAsync (baseUrl);
		}


		private async void FetchLanguagesAsync(string baseUrl)
		{
			string endpoint = "/languages";
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (baseUrl + endpoint));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ())
			{
				using (Stream stream = response.GetResponseStream ())
				{
					var streamReader = new StreamReader (stream);
					var jsonContents = streamReader.ReadToEnd ();
					var languages = JsonConvert.DeserializeObject<List<Language>> (jsonContents);
					this.Languages = languages;
					CachingService.instance.PersistCache (CachedResponse.Languages, jsonContents);
					if (OnLanguagesUpdated != null) {
						OnLanguagesUpdated ();
					}
				}
			}
		}

		private void createDefaultCache() 
		{
			var languages = new List<Language> () {
				new Language () {
					Name = "English",
					Code = "default"
				}
			};

			var json = JsonConvert.SerializeObject (languages);
			CachingService.instance.PersistCache (CachedResponse.Languages, json);
		}

		private List<Language> parseFromCache()
		{
			var json = CachingService.instance.GetCache (CachedResponse.Languages);
			return JsonConvert.DeserializeObject<List<Language>> (json);
		}
	}
}

