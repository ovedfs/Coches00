using Coches00.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coches00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarDetailPage : TabbedPage
	{
        protected Car car;
        protected User user;

		public CarDetailPage (Car car)
		{
			InitializeComponent ();
            this.car = car;
            this.user = (Application.Current as App).UserData;

            BindingContext = car;
		}
	}
}