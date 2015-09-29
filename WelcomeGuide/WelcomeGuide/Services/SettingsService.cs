using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;

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

		private SettingsService ()
		{
		}

		public string GetSetting (string name)
		{
			string settingsPath = name + ".txt";
			using (IsolatedStorageFile store = IsolatedStorageFile.GetStore (IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null)) {
				if (store.FileExists (settingsPath)) {
					using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream (settingsPath, FileMode.Open, store)) {
						using (StreamReader reader = new StreamReader (isoStream)) {
							return reader.ReadToEnd ();
						}
					}
				}
			}
			return null;
		}

		public void PersistSetting (string name, string setting)
		{
			string settingsPath = name + ".txt";
			using (IsolatedStorageFile store = IsolatedStorageFile.GetStore (IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null)) {
				using (IsolatedStorageFileStream isoStream = store.CreateFile (settingsPath)) {
					using (StreamWriter writer = new StreamWriter (isoStream)) {
						writer.WriteLine (setting.ToString ());
					}
				}  
			}
		}

		// Convenience Methods
		//
		public bool HasSeenOnboarding {
			get {
				return GetSetting ("HasSeenOnboarding") == "true";
			} 
			set {
				PersistSetting ("HasSeenOnboarding", "true");
			}
		}

		public string Language {
			get {
				return GetSetting ("Language");
			} 
			set {
				PersistSetting ("Language", value);
			}
		}

		public string Location {
			get {
				return GetSetting ("Location");
			}
			set {
				PersistSetting ("Location", value);
			}
		}
	}
}