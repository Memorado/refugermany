﻿using System;
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
								Content = @"<html><body><h1>Xamarin.Forms</h1><p>Welcome to WebView. <a href=""http://www.w3schools.com/html/"">Visit our HTML tutorial</a></p></body></html>"
							},
							new TextArticle { 
								Title = "Wait for the LaGeSo",
								Content = @"<html><body><h1>Xamarin.Forms</h1><p>Welcome to WebView. <a href=""http://www.w3schools.com/html/"">Visit our HTML tutorial</a></p></body></html>"
							},
							new TextArticle { 
								Title = "Wait for the interview",
								Content = @"<html><body><h1>Xamarin.Forms</h1><p>Welcome to WebView. <a href=""http://www.w3schools.com/html/"">Visit our HTML tutorial</a></p></body></html>"
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
