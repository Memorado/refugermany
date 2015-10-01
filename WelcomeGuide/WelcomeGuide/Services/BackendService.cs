using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace WelcomeGuide
{
	public class BackendService<T>
	{
		public T Data { get; protected set; }
		public bool Fetching { get; protected set; }

		public event Action OnDataChanged;
		public event Action<Exception> OnError;

		private string _baseUrl = "https://refhelp.herokuapp.com:443/api/v1";
		private string _endpoint;
		private CachedResponse _cacheType;

		public BackendService (string endpoint, string offlineCache, CachedResponse cacheType)
		{
			this._endpoint = endpoint;
			this._cacheType = cacheType;

			var cachedResponse = CachingService.instance.GetCache (_cacheType);
			if (cachedResponse == null) {
				createDefaultCache (offlineCache);
			}
			this.Data = parseFromCache ();
		}

		public virtual async void FetchDataAsync ()
		{
			if (!ReachabilityService.instance.IsNetworkReachable) {
				return;
			}

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (_baseUrl + _endpoint));
			request.ContentType = "application/json";
			request.Method = "GET";
			request.Headers ["X-Language"] = SettingsService.instance.Language;
			request.Headers ["X-Location"] = SettingsService.instance.Location;

			try {
				Fetching = true;
				using (WebResponse response = await request.GetResponseAsync ()) {
					using (Stream stream = response.GetResponseStream ()) {
						var streamReader = new StreamReader (stream);
						var jsonContents = streamReader.ReadToEnd ();
						this.Data = JsonConvert.DeserializeObject<T> (jsonContents);
						CachingService.instance.PersistCache (_cacheType, jsonContents);
						if (OnDataChanged != null) {
							OnDataChanged ();
						}
						Fetching = false;
					}
				}
			} catch (Exception e){
				Console.WriteLine ("Couldn't retrieve Data for " + _endpoint);
				Console.WriteLine ("Error was " + e.Message);
				Fetching = false;
				if (OnError != null) {
					OnError (e);
				}
			}
		}

		private T parseFromCache ()
		{
			var json = CachingService.instance.GetCache (_cacheType);
			return JsonConvert.DeserializeObject<T> (json);
		}

		private void createDefaultCache (string offlineVersionPath)
		{
			string contents = ResourcesHelper.LoadResource (offlineVersionPath);
			CachingService.instance.PersistCache(_cacheType, contents);
		}
	}
}

