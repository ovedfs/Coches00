using Coches00.Models;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coches00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPenaltyPage : ContentPage
	{
        protected string ImagePathTemp;

        public AddPenaltyPage (Car car)
		{
			InitializeComponent ();

            BindingContext = car;
		}

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryMonto.Text) ||
                string.IsNullOrWhiteSpace(ImagePathTemp))
            {
                await DisplayAlert("Error", "Todos los datos son obligatorios (excepto las observaciones)", "OK");
                return;
            }

            Penalty penalty = new Penalty
            {
                FechaMulta = PickerFechaMulta.Date,
                Monto = Convert.ToDouble(entryMonto.Text),
                Pagada = switchPagada.IsToggled,
                FechaPago = PickerFechaPago.Date,
                Archivo = ImagePathTemp,
                Observaciones = entryObservaciones.Text,
                CarId = (BindingContext as Car).Id
            };

            try
            {
                int saved = await PenaltyHelper.SaveItemAsync(penalty);
                await DisplayAlert("Guardar", "¡Multa registrada correctamente!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Hubo un error verifique con el Administrador", "OK");
                return;
            }
        }

        async private void fotoPicker_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                string fileName = fileData.FileName;

                string path = DependencyService.Get<IFileManager>().SaveFile(fileData.DataArray);

                if (path != "Error")
                {
                    foto.Source = path;
                    ImagePathTemp = path;
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }
    }
}