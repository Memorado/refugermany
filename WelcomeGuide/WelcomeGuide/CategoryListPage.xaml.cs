﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class CategoryListPage : ContentPage
	{
		public CategoryListViewModel viewModel = new CategoryListViewModel();

		public CategoryListPage ()
		{
			InitializeComponent ();
			myListView.ItemsSource = viewModel.categories;
		}

		public void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Category selectedCategory = ((CategoryViewModel)e.SelectedItem).Category;
			ArticleListPage nextPage = new ArticleListPage () { ViewModel = new ArticleListViewModel () { Category = selectedCategory } };
			Navigation.PushAsync (nextPage);
		}
	}
}
