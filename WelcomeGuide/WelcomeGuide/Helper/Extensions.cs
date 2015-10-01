using System;
using System.Globalization;

namespace WelcomeGuide.Extensions
{
	public static class StringExtensions
	{
		public static bool ContainedInAny (this string searchTerm, params string[] sources)
		{
			var compareInfo = CultureInfo.CurrentCulture.CompareInfo;
			foreach (var source in sources) {
				var contains = compareInfo.IndexOf (source, searchTerm, CompareOptions.OrdinalIgnoreCase) >= 0;
				if (contains) {
					return true;
				}
			}

			return false;
		}
	}
}

