using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

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
			var compareInfo = CultureInfo.CurrentCulture.CompareInfo;
			return Category.Articles
				.Where ((article) => compareInfo.IndexOf(article.Keywords, searchTerm, CompareOptions.OrdinalIgnoreCase) >= 0 )
				.Select((article) => new ArticleViewModel() { Article = article });
		}
	}
}

