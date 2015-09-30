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

			this.ToolbarItems.Add (new ToolbarItem ("Settings", "settings.png", () => {
				Navigation.PushAsync (new SettingsPage ());
			}));
		}

		protected override void OnAppearing ()
		{				
			CategoriesService.instance.OnDataChanged += OnCategoriesDownloaded;
			CategoriesService.instance.OnError += OnCategoriesFetchError;
			MessagingCenter.Subscribe<CategoriesService> (this, Constants.MessageCategoriesUpdating, OnCategoriesUpdating);
			SetBusy(CategoriesService.instance.Fetching);
		}

		void OnCategoriesUpdating (CategoriesService service)
		{
			SetBusy(service.Fetching);
		}

		protected override void OnDisappearing ()
		{			
			SetBusy(false);
		}

		void OnCategoriesDownloaded ()
		{
			ViewModel = new CategoryListViewModel (CategoriesService.instance.Data);
			myListView.ItemsSource = ViewModel.categories;
			SetBusy(false);
		}

		void OnCategoriesFetchError (Exception obj)
		{
			DisplayAlert ("Error", "Couldn't update from internet. Try again later.", "Dismiss");
			SetBusy(false);
		}

		public void OnListItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				if (e.SelectedItem is CategoryViewModel) {
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
				} else if (e.SelectedItem is ArticleViewModel) {
					ArticleViewModel selectedSearchArtile = (ArticleViewModel)e.SelectedItem;
					var articlePage = new TextArticlePage () { ViewModel = selectedSearchArtile };
					Navigation.PushAsync (articlePage);
						
				}
				myListView.SelectedItem = null;
			}
		}

		public async void OnSearchCompleted (object sender, EventArgs e)
		{
			var searchTerm = entrySearch.Text;
			if (String.IsNullOrWhiteSpace (searchTerm)) {
				myListView.ItemsSource = ViewModel.categories;
			} else {
				SetBusy (true);
				var results = await ViewModel.SearchAsync (searchTerm);
				SetBusy (false);
				myListView.ItemsSource = results;
			}
		}

		private void SetBusy(bool isBusy)
		{
			activityIndicator.Opacity = isBusy ? 1 : 0;
		}
	}
}

