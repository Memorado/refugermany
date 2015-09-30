using System;
using System.Collections.Generic;

namespace WelcomeGuide
{
	public class Category
	{
		public int Position { get; set; }
		public String Name { get; set; }
		public String Language { get; set; }
		public List<TextArticle> Articles { get; set; }
		public String Icon { get; set; }

		public Category ()
		{
			Articles = new List<TextArticle> ();
		}
	}
}

