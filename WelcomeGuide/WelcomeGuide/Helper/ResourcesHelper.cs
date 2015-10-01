using System;
using System.IO;
using System.Reflection;

namespace WelcomeGuide
{
	public class ResourcesHelper
	{
		public static string LoadResource(string resourceName)
		{
			#if __IOS__
			var resourcePrefix = "WelcomeGuide.iOS.Resources.";
			#endif
			#if __ANDROID__
			var resourcePrefix = "WelcomeGuide.Droid.Resources.";
			#endif

			var assembly = typeof(CategoriesService).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (resourcePrefix + resourceName);
			StreamReader sr = new StreamReader (stream);
			String contents = sr.ReadToEnd ();
			return contents;
		}
	}
}

