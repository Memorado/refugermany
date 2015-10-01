using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class TextArticlePage : ContentPage
	{
		public ArticleViewModel ViewModel { get; set; }

		public TextArticlePage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			//fill-in info
			var htmlSource = new HtmlWebViewSource ()
			{
				Html = ViewModel.HtmlText
			};
			this.webView.Source = htmlSource;

			this.webView.Navigating += (s, e) =>
			{
				if (e.Url.StartsWith("http"))
				{
					try
					{
						var uri = new Uri(e.Url);
						Device.OpenUri(uri);
					}
					catch (Exception)
					{
					}

					e.Cancel = true;
				}
			};

			this.Title = ViewModel.Title;
			
		}
	}
}

