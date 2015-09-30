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
			OnCategoriesDownloaded ();
		}

		protected override void OnAppearing ()
		{			
			CategoriesService.instance.OnDataChanged += OnCategoriesDownloaded;
		}

		protected override void OnDisappearing ()
		{			
			CategoriesService.instance.OnDataChanged -= OnCategoriesDownloaded;
		}

		void OnCategoriesDownloaded ()
		{
			_viewModel = new CategoryListViewModel (CategoriesService.instance.Data);
			myListView.ItemsSource = _viewModel.categories;
		}

		public void OnListItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				Category selectedCategory = ((CategoryViewModel)e.SelectedItem).Category;

				//probably should not display category at all, but now its better than crash
				if (selectedCategory.Articles.Count == 0)
					return; 
				
				ContentPage nextPage;
				if (selectedCategory.Articles.Count > 1) {
					nextPage = new ArticleListPage () { ViewModel = new ArticleListViewModel () { Category = selectedCategory } };
				} else {
					nextPage = new TextArticlePage () { ViewModel = new ArticleViewModel () { Article = selectedCategory.Articles [0] } };
				}
				Navigation.PushAsync (nextPage);
				myListView.SelectedItem = null;
			}
		}
	}
}

