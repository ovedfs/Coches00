using Coches00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coches00
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();  
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasBackButton(this, false);
        }

        async private void LoginButton_Clicked(object sender, EventArgs e)
        {
            User user = await UserHelper.UserExist(entryEmail.Text, entryPassword.Text);

            if (user == null)
            {
                await DisplayAlert("Login error", "Datos incorrectos, verifique por favor", "OK");
                return;
            }

            await DisplayAlert("User", "Datos correctos, bienvenido(a) " + user.Name, "OK");

            (Application.Current as App).IsLoggedIn = true;
            (Application.Current as App).UserData = user;

            await (Application.Current as App).SavePropertiesAsync();

            await Navigation.PushAsync(new MainPage(user));
        }

        async private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}