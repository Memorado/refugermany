﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms;

namespace WelcomeGuide
{
	public class CategoriesService : BackendService<List<Category>>
	{
		// Singleton
		private static CategoriesService _instance;
		public static CategoriesService instance {
			get {
				if (_instance == null) {
					_instance = new CategoriesService ();
				}
				return _instance;
			}
		}

		private CategoriesService ()
			:base("/categories", "categories.json", CachedResponse.Categories)
		{
			
		}

		public override async void FetchDataAsync ()
		{
			MessagingCenter.Send (this, Constants.MessageCategoriesUpdating);
			base.FetchDataAsync ();
		}

	}
}

