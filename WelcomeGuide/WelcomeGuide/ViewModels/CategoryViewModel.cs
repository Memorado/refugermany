using System;
using System.Collections.Generic;
using System.Linq;

namespace WelcomeGuide
{
	public class CategoryViewModel
	{
		public Category Category { get; private set; }

		public String DetailText {
			get {
				return Category.Articles.Count + " articles";
			}
		}

		public String Title {
			get {
				return Category.Name;
			}
		}

		public CategoryViewModel (Category category)
		{
			this.Category = category;
		}
	}
}

