using System;

namespace WelcomeGuide
{
	public class ArticleViewModel
	{
		public TextArticle Article { get; set; }

		public String Title {
			get {
				return Article.Title;
			}
		}

		public String Preview {
			get {
				return Article.Content.Substring (0, 20) + " ...";
			}
		}

		public ArticleViewModel ()
		{
		}
	}
}

