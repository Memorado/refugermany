using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class CategoryListPage : ContentPage
	{
		public CategoryListViewModel ViewModel { get; private set; }

		public CategoryListPage ()
		{
			InitializeComponent ();
			OnCategoriesDownloaded ();
		}

		protected override void OnAppearing ()
		{				
			CategoriesService.instance.OnDataChanged += OnCategoriesDownloaded;
			CategoriesService.instance.OnError += OnCategoriesFetchError;
			MessagingCenter.Subscribe<CategoriesService> (this, Constants.MessageCategoriesUpdating, OnCategoriesUpdating);
			activityIndicator.IsVisible = CategoriesService.instance.Fetching;
		}

		void OnCategoriesUpdating(CategoriesService service)
		{
			activityIndicator.IsVisible = service.Fetching;
		}

		protected override void OnDisappearing ()
		{			
			activityIndicator.IsVisible = false;
		}

		void OnCategoriesDownloaded ()
		{
			ViewModel = new CategoryListViewModel (CategoriesService.instance.Data);
			myListView.ItemsSource = ViewModel.categories;
			activityIndicator.IsVisible = false;
		}

		void OnCategoriesFetchError (Exception obj)
		{
			DisplayAlert ("Error", "Couldn't update from internet. Try again later.", "Dismiss");
			activityIndicator.IsVisible = false;
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
					nextPage = new ArticleListPage () { ViewModel = new ArticleListViewModel (selectedCategory)  };
				} else {
					nextPage = new TextArticlePage () { ViewModel = new ArticleViewModel () { Article = selectedCategory.Articles [0] } };
				}
				Navigation.PushAsync (nextPage);
				myListView.SelectedItem = null;
			}
		}
	}
}

