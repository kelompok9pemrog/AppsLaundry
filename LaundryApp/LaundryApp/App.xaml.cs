using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaundryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        private void LaundryApp()
        {
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }
    }
}
