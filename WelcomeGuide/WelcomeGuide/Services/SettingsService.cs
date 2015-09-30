using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using Newtonsoft.Json;

namespace WelcomeGuide
{
	public class SettingsService
	{
		// Singleton
		private static SettingsService _instance;

		public static SettingsService instance {
			get {
				if (_instance == null) {
					_instance = new SettingsService ();
				}
				return _instance;
			}
		}

		private string settingsPath
		{
			get {
				var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				var filePath = Path.Combine (documentsPath, "ApplicationSettings");
				return filePath;
			}
		}

		private SettingsService ()
		{
			if (!File.Exists (settingsPath)) {
				var defaultSettings = new Settings () {
					HasSeenOnboarding = false,
					Language = "English",
					Location = "Berlin"
				};
				var defaultJson = JsonConvert.SerializeObject (defaultSettings);
				File.WriteAllText (settingsPath, defaultJson);
			}
		}

		public Settings GetSettings ()
		{
			var settingsJson = File.ReadAllText (settingsPath);
			var settings = JsonConvert.DeserializeObject<Settings> (settingsJson);
			return settings;
		}

		public void PersistSettings (Settings settings)
		{
			var settingsJson = JsonConvert.SerializeObject (settings);
			File.WriteAllText (settingsPath, settingsJson);
		}

		// Convenience Methods
		//
		public bool HasSeenOnboarding {
			get {
				return GetSettings ().HasSeenOnboarding;
			} 
			set {
				var settings = GetSettings();
				settings.HasSeenOnboarding = value;
				PersistSettings(settings);
			}
		}

		public string Language {
			get {
				return GetSettings ().Language;
			} 
			set {
				var settings = GetSettings();
				settings.Language = value;
				PersistSettings(settings);
			}
		}

		public string LanguageName {
			get {
				return GetSettings ().LanguageName;
			} 
			set {
				var settings = GetSettings();
				settings.LanguageName = value;
				PersistSettings(settings);
			}
		}

		public string Location {
			get {
				return GetSettings ().Location;
			}
			set {
				var settings = GetSettings();
				settings.Location = value;
				PersistSettings(settings);
			}
		}
	}
}