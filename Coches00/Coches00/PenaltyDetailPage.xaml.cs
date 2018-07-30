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
	public partial class PenaltyDetailPage : ContentPage
	{
		public PenaltyDetailPage (Penalty penalty)
		{
			InitializeComponent ();
            BindingContext = penalty;
		}

        async private void BtnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}