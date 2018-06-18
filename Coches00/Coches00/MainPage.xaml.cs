using Coches00.Models;
using System;
using Xamarin.Forms;

namespace Coches00
{
    public partial class MainPage : ContentPage
	{
        protected User user;

		public MainPage(User loggedUser)
		{
			InitializeComponent();

            if (!(Application.Current as App).IsLoggedIn)
            {
                Navigation.PushAsync(new LoginPage());
            }

            //Console.WriteLine((Application.Current as App).IsLoggedIn);
            //Console.WriteLine(loggedUser.Name);

            this.user = loggedUser;
            BindingContext = loggedUser;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasBackButton(this, false);

            var cars = await CarHelper.GetCars(this.user);

            CarsListView.ItemsSource = cars;
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCarPage());
        }

        async private void CarsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var car = e.SelectedItem as Car;

            await Navigation.PushAsync(new CarDetailPage(car));
        }
    }
}
