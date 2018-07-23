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
	public partial class AddFilePage : ContentPage
	{
        protected string ImagePathTemp = "";

        public AddFilePage (Car car)
		{
			InitializeComponent ();

            BindingContext = car;
		}

        async private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryTitulo.Text) ||
                string.IsNullOrWhiteSpace(entryDescripcion.Text) ||
                string.IsNullOrWhiteSpace(entryNota.Text))
            {
                await DisplayAlert("Error", "Todos los datos son obligatorios", "OK");
                return;
            }

            File file = new File
            {
                Titulo = entryTitulo.Text,
                Descripcion = entryDescripcion.Text,
                Nota = entryNota.Text,
                Archivo = ImagePathTemp,
                CarId = (BindingContext as Car).Id
            };

            try
            {
                int saved = await FileHelper.SaveItemAsync(file);
                await DisplayAlert("Guardar", "¡Documento guardado correctamente!", "OK");
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