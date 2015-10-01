using System;
using System.Collections.Generic;

namespace WelcomeGuide
{
	public class ArticleViewModel
	{
		public TextArticle Article { get; private set; }
		public String HtmlText { get; private set; }

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

		public ArticleViewModel(TextArticle article)
		{
			this.Article = article;
			var htmlHead = String.Format("<head><style type=\"text/css\">{0}</style></head>", ResourcesHelper.LoadResource("article.css"));
			this.HtmlText = htmlHead + article.Content;
		}
	}
}

