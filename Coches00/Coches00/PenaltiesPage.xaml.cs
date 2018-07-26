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
	public partial class PenaltiesPage : ContentPage
	{
		public PenaltiesPage ()
		{
			InitializeComponent ();
		}

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            var car = BindingContext as Car;

            var penalties = await PenaltyHelper.GetPenalties(car);

            PenaltiesListView.ItemsSource = penalties;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync();
        }

        private void PenaltiesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}