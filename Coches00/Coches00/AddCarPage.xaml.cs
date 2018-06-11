using Coches00.Models;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
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
	public partial class AddCarPage : ContentPage
	{
        Dictionary<string, Color> ColorNames = new Dictionary<string, Color>
        {
            {"Azul", Color.Blue }, {"Rojo", Color.Red}, {"Verde", Color.Green}, {"Negro", Color.Black}, {"Blanco", Color.White},
            {"Naranja", Color.Orange}, {"Cafe", Color.Brown}
        };

        List<string> cities = new List<string>
        {
            "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", "Chiapas", "Chihuahua", "Ciudad de México",
            "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México", "Michoacán", "Morelos",
            "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo", "San Luis Potosí", "Sinaloa", "Sonora",
            "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"
        };

        protected string ImagePathTemp = "";

		public AddCarPage ()
		{
			InitializeComponent ();
            InitColorPicker();
            InitCityPicker();
        }

        private void InitCityPicker()
        {
            CityPicker.ItemsSource = cities;
        }

        private void InitColorPicker()
        {
            foreach (string color in ColorNames.Keys)
            {
                ColorPicker.Items.Add(color);
            }

            ColorPicker.SelectedIndexChanged += (s, e) => 
            {
                if(ColorPicker.SelectedIndex == -1)
                {
                    ColorBoxView.Color = Color.Default;
                }
                else
                {
                    string colorTemp = ColorPicker.SelectedItem.ToString();
                    ColorBoxView.Color = ColorNames[colorTemp];
                }
            };
        }

        async private void SaveButton_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("Info", ImagePathTemp, "OK");
            //return;
            
            if (string.IsNullOrWhiteSpace(entryPlacas.Text) ||
                string.IsNullOrWhiteSpace(entryMarca.Text) ||
                string.IsNullOrWhiteSpace(entryModelo.Text) ||
                ColorPicker.SelectedIndex == -1 ||
                CityPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Todos los datos son obligatorios", "OK");
                return;
            }

            Car car = new Car
            {
                Placas = entryPlacas.Text,
                Marca = entryMarca.Text,
                Modelo = Convert.ToInt32(entryModelo.Text),
                Color = ColorPicker.SelectedItem.ToString(),
                Foto = ImagePathTemp,
                Estado = CityPicker.SelectedItem.ToString(),
                Alias = entryAlias.Text,
                UserId = (Application.Current as App).UserData.Id
            };

            try
            {
                int saved = await CarHelper.SaveItemAsync(car);
                await DisplayAlert("Guardar", "¡Coche guardado correctamente!", "OK");
                await Navigation.PopAsync();
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

        async private void ChoiceFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                string fileName = fileData.FileName;
                //string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);

                string path = DependencyService.Get<IFileManager>().SaveFile(fileData.DataArray);

                if (path != "Error")
                {
                    foto.Source = path;
                    ImagePathTemp = path;
                    //await DisplayAlert("Info", path, "OK");
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }
    }
}