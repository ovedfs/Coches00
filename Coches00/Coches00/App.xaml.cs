using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Coches00
{
    public partial class App : Application
    {
        private const string isLoggedInProperty = "UserLoggedIn";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public bool IsLoggedIn
        {
            get
            {
                if (Properties.ContainsKey(isLoggedInProperty))
                {
                    return (bool)Properties[isLoggedInProperty];
                }

                Properties[isLoggedInProperty] = false;
                return (bool)Properties[isLoggedInProperty];
            }
            set
            {
                Properties[isLoggedInProperty] = value;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
