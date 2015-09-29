using System;

namespace WelcomeGuide
{
	public class PDFArticle : IContentArticle
	{
		public String Title { get; set; } 
		public String Url { get; set; }
		public Byte[] Cached { get; set; }

		public PDFArticle ()
		{
			
		}
	}
}

