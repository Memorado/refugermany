using System;
using System.IO;

namespace WelcomeGuide
{
	public enum CachedResponse 
	{
		NONE,
		Categories,
		Languages,
		Locations
	}

	public class CachingService
	{
		// Singleton
		private static CachingService _instance;
		public static CachingService instance {
			get {
				if (_instance == null) {
					_instance = new CachingService ();
				}
				return _instance;
			}
		}

		public string GetCache(CachedResponse response) 
		{
			var path = cachePath (response);
			if (File.Exists(path)) {
				return File.ReadAllText (path);	
			} 

			return null;
		}

		public void PersistCache(CachedResponse response, string contents)
		{
			File.WriteAllText (cachePath (response), contents);
		}

		private string cachePath(CachedResponse response)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, Enum.GetName(typeof(CachedResponse), response));
			return filePath;
		}
	}
}

