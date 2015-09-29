using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class ArticleListPage : ContentPage
	{
		public ArticleListViewModel ViewModel;

		public ArticleListPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			myListView.ItemsSource = ViewModel.ArticleViewModels;
		}

		public void OnArticleSelected (object sender, SelectedItemChangedEventArgs e)
		{
			TextArticle selectedArticle = ((ArticleViewModel)e.SelectedItem).Article;
			TextArticlePage nextPage = new TextArticlePage () { 
				ViewModel = new ArticleViewModel () { 
					Article = selectedArticle 
				} 
			};
			Navigation.PushAsync (nextPage);
		}
	}
}

