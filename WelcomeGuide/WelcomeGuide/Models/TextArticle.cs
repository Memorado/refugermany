using System;

namespace WelcomeGuide
{
	public class TextArticle : IContentArticle
	{
		public String Title { get; set; }
		public String Content { get; set; }
		public String Keywords { get; set; }
		public int Position { get; set; }

		public TextArticle ()
		{
		}
	}
}

