using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WelcomeGuide
{
	public class CategoryListViewModel
	{
		public List<CategoryViewModel> categories;

		public CategoryListViewModel (List<Category> categories)
		{
			this.categories = 
				categories
					.Select (c => new CategoryViewModel (c))
					.OrderBy (c => c.Category.Position)
					.ToList ();
		}

		public async Task<List<ArticleViewModel>> SearchAsync (string searchTerm)
		{
			var results = new List<ArticleViewModel> ();

			foreach (var category in categories) {
				results.AddRange (await Task.Factory.StartNew(() => { return category.Search (searchTerm);}));
			}

			return results;
		}
	}
}

