using System;
using System.Collections.Generic;

namespace WelcomeGuide
{
	public class Category
	{
		public String Title { get; set; }
		public List<TextArticle> Articles { get; set; }

		public Category ()
		{
			Articles = new List<TextArticle> ();
		}
	}
}

