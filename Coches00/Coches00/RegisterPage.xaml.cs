using Coches00.Models;
using SQLite;
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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(entryName.Text) ||
                string.IsNullOrWhiteSpace(entryEmail.Text) ||
                string.IsNullOrWhiteSpace(entryPassword.Text) ||
                string.IsNullOrWhiteSpace(entryConfirmPassword.Text))
            {
                await DisplayAlert("Error", "Todos los datos son obligatorios", "OK");
                return;
            }

            if (!IsValidEmail(entryEmail.Text))
            {
                await DisplayAlert("Error", "El correo no tiene un formato valido", "OK");
                return;
            }

            if (! entryPassword.Text.Equals(entryConfirmPassword.Text))
            {
                await DisplayAlert("Error", "Los passwords no coinciden", "OK");
                return;
            }

            var user = new User
            {
                Name = entryName.Text,
                Email = entryEmail.Text,
                Password = entryPassword.Text  // Hash password for security 
            };

            try
            {
                int saved = await UserHelper.SaveItemAsync(user);
                await DisplayAlert("Registro", "Cuenta creada correctamente, ahora puede iniciar sesión", "OK");
                await Navigation.PopAsync();
            }
            catch (SQLiteException)
            {
                await DisplayAlert("Error", $"Error al guardar en la base de datos, verifique que el correo {entryEmail.Text} no haya sido usado", "OK");
                return;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Hubo un error verifique con el Administrador", "OK");
                return;
            }
        }

        async private void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}