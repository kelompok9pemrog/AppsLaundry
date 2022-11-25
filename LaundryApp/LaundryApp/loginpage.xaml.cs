using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaundryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginpage : ContentPage
    {
        public loginpage()
        {
            InitializeComponent();
        }

        private void Btnstart_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Name"] = Userentry.Text;
            Navigation.PushAsync(new homepage());
        }
    }
}