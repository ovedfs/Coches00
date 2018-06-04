using Coches00.Models;
using Xamarin.Forms;

namespace Coches00
{
    public partial class MainPage : ContentPage
	{
        protected User user;

		public MainPage(User user)
		{
			InitializeComponent();
            this.user = user;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!(Application.Current as App).IsLoggedIn)
            {
                await Navigation.PushAsync(new LoginPage());
            }

            NavigationPage.SetHasBackButton(this, false);

            var cars = await CarHelper.GetCars(user);

            CarsListView.ItemsSource = cars;
        }
    }
}
