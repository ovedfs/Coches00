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
	public partial class EditPenaltyPage : ContentPage
	{
        protected string ImagePathTemp;

        public EditPenaltyPage (Penalty penalty)
		{
			InitializeComponent ();

            BindingContext = penalty;
            ImagePathTemp = penalty.Archivo;

            BtnDetailFoto.Image = (FileImageSource)ImageSource.FromFile("zoom.png");
            fotoPicker.Image = (FileImageSource)ImageSource.FromFile("search.png");

        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryMonto.Text) ||
                string.IsNullOrWhiteSpace(ImagePathTemp))
            {
                await DisplayAlert("Error", "El monto es un dato obligatorio", "OK");
                return;
            }

            var penalty = (BindingContext as Penalty);
            penalty.FechaMulta = PickerFechaMulta.Date;
            penalty.Monto = Convert.ToDouble(entryMonto.Text);
            penalty.Pagada = switchPagada.IsToggled;
            penalty.FechaPago = PickerFechaPago.Date;
            penalty.Archivo = ImagePathTemp;
            penalty.Observaciones = entryObservaciones.Text;

            try
            {
                int saved = await PenaltyHelper.SaveItemAsync(penalty);
                await DisplayAlert("Guardar", "¡Multa actualizada correctamente!", "OK");
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

        async private void BtnDetailFoto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PenaltyDetailPage(BindingContext as Penalty));
        }
    }
}