using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class ArticlePage : ContentPage
	{
		public ArticleViewModel ViewModel = new ArticleViewModel();

		public ArticlePage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			//fill-in info
			var htmlSource = new HtmlWebViewSource ()
			{
				Html = 
					@"<html><body>
 		 			<h1>Xamarin.Forms</h1>
  					<p>Welcome to WebView. <a href=""http://www.w3schools.com/html/"">Visit our HTML tutorial</a></p>
 				</body></html>"
			};
			webView.Source = htmlSource;

			webView.Navigating += (s, e) =>
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
		}
	}
}

