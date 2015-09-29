using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WelcomeGuide
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}

		public void OnContinueClicked(object sender, EventArgs e) 
		{
			Navigation.PushAsync (new CategoryListPage ());
		}
	}
}

