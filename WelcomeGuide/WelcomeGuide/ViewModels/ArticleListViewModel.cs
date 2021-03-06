﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WelcomeGuide
{
	public class ArticleListViewModel
	{
		public Category Category { get; private set; }

		public List<ArticleViewModel> ArticleViewModels { get; private set; }

		public ArticleListViewModel (Category category)
		{
			this.Category = category;
			this.ArticleViewModels = category.Articles
				.Select (a => new ArticleViewModel(a))
				.OrderBy (a => a.Article.Position)
				.ToList();
		}
	}
}

