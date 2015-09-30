using System;
using System.Collections.Generic;
using System.Linq;

namespace WelcomeGuide
{
	public class CategoryListViewModel
	{
		public List<CategoryViewModel> categories;

		public bool Busy { 
			get {
				return CategoriesService.instance.Fetching;
			} 
		}

		public CategoryListViewModel (List<Category> categories)
		{
			this.categories = 
				categories
					.Select (c => new CategoryViewModel (c))
					.OrderBy(c => c.Category.Position)
					.ToList();
		}
	}
}

