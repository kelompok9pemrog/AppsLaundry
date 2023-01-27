using MySqlConnector;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            MySqlCommand cmd = new MySqlCommand("select * from user where username='" + Userentry.Text + "' and password='" + Passwentry.Text + "'", koneksi);
            var rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                Application.Current.Properties["UserInfo"]=Userentry.Text;
                Navigation.PushAsync(new homepage());
            }
            else if (String.IsNullOrEmpty(Userentry.Text))
            {
                DisplayAlert("Alert", "Input username", "OK");
            }
            else if (String.IsNullOrEmpty(Passwentry.Text))
            {
                DisplayAlert("Alert", "Input password", "OK");
            }
            else
            {
                DisplayAlert("Warning", "Can't find your account", "OK");
            }
        }

        private void Btnreg_Clicked(object sender, EventArgs e)
        {
        Navigation.PushAsync(new registerpage());
        
        }

        private void Btnreg1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registerpage());
        }

        private void Btnlogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginpage());
        }
    }
}