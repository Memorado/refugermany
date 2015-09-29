using System;
using System.Collections.Generic;
using System.Linq;

namespace WelcomeGuide
{
	public class ArticleListViewModel
	{
		public Category Category;

		public List<ArticleViewModel> ArticleViewModels { 
			get {
				return Category.Articles.Select (a => new ArticleViewModel { Article = a }).ToList();
			}
		}

		public ArticleListViewModel ()
		{
		}
	}
}

