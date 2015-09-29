using System;
using System.Collections.Generic;

namespace WelcomeGuide
{
	public class CategoryListViewModel
	{
		public List<CategoryViewModel> categories;

		public CategoryListViewModel ()
		{
			categories = new List<CategoryViewModel> ();
			categories.Add (
				new CategoryViewModel { Category = new Category {
						Title = "Welcome to Berlin", 
						Articles = {
							new TextArticle { 
								Title = "Registering with the Police",
								Content = "Article text here Article text here Article text here Article text here Article text here "
							},
							new TextArticle { 
								Title = "Wait for the LaGeSo",
								Content = "Article text here Article text here Article text here Article text here Article text here "
							},
							new TextArticle { 
								Title = "Wait for the interview",
								Content = "Article text here Article text here Article text here Article text here Article text here "
							},
						} 
					}
				}
			);
			categories.Add (
				new CategoryViewModel { Category = new Category {
						Title = "Find an appartment", 
						Articles = {
							new TextArticle { 
								Title = "Article 1",
								Content = "Article text here Article text here Article text here Article text here Article text here "
							},
						} 
					}
				}
			);


		}
	}
}

