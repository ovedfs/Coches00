using Coches00.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Coches00
{
    public partial class App : Application
    {
        private const string loginKey = "UserLoggedIn";
        private const string userKey = "User";

        public App()
        {
            InitializeComponent();

            if (IsLoggedIn && UserData != null)
            {
                MainPage = new NavigationPage(new MainPage(UserData));
            }

            MainPage = new NavigationPage(new LoginPage());
        }

        public bool IsLoggedIn
        {
            get
            {
                if (Properties.ContainsKey(loginKey))
                {
                    return (bool)Properties[loginKey];
                }

                Properties[loginKey] = false;
                return (bool)Properties[loginKey];
            }
            set
            {
                Properties[loginKey] = value;
            }
        }

        public User UserData
        {
            get
            {
                if (Properties.ContainsKey(userKey))
                {
                    return (User)Properties[userKey];
                }

                Properties[userKey] = null;
                return (User)Properties[userKey];
            }
            set
            {
                Properties[userKey] = value;
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
