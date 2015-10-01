using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using WelcomeGuide.Extensions;

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

		public String IconSource {
			get {
				return Category.Icon;
			}
		}

		public CategoryViewModel (Category category)
		{
			this.Category = category;
		}

		public IEnumerable<ArticleViewModel> Search(string searchTerm) 
		{
			return Category.Articles
				.Where ((a) => searchTerm.ContainedInAny(a.Keywords, a.Title, a.Content))
				.Select((a) => new ArticleViewModel(a) );
		}
	}
}

