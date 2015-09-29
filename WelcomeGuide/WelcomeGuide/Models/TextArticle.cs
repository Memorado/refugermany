using System;

namespace WelcomeGuide
{
	public class TextArticle : IContentArticle
	{
		public String Title { get; set; }
		public String Content { get; set; }

		public TextArticle ()
		{
		}
	}
}

