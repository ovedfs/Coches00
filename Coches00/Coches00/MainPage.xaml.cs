﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Coches00
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!Application.Current.Properties.ContainsKey("IsLoggedIn") || (bool)Application.Current.Properties["IsLoggedIn"] == false)
            {
                await Navigation.PushAsync(new LoginPage());
            }

            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
