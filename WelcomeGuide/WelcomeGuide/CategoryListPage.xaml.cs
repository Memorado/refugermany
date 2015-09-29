using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class CategoryListPage : ContentPage
	{
		private CategoryListViewModel _viewModel;

		public CategoryListPage ()
		{
			InitializeComponent ();
			_viewModel = new CategoryListViewModel (ArticlesService.instance.Categories);
			myListView.ItemsSource = _viewModel.categories;
		}

		public void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Category selectedCategory = ((CategoryViewModel)e.SelectedItem).Category;
			ArticleListPage nextPage = new ArticleListPage () { ViewModel = new ArticleListViewModel () { Category = selectedCategory } };
			Navigation.PushAsync (nextPage);
		}
	}
}

