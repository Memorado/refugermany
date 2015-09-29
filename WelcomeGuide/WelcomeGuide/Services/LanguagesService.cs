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
			this.Languages = new List<Language> () {
				new Language() { Name="English"}
			};	
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
					if (OnLanguagesUpdated != null) {
						OnLanguagesUpdated ();
					}
				}
			}
		}
	}
}

