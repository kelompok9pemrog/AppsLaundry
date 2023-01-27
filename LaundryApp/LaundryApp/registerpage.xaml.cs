using MySqlConnector;
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
	public partial class registerpage : ContentPage
	{
		public registerpage ()
		{
			InitializeComponent ();
		}

        private void Btnlogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginpage());
        }

        private void Btnlogin1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginpage());
        }

        private void Btninput_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Userentry.Text))
            {
                DisplayAlert("Alert", "Fill the data", "OK;");
            } else if (String.IsNullOrEmpty(Passwentry.Text))
            {
                DisplayAlert("Alert", "Fill the data", "OK;");
            }
            else if (String.IsNullOrEmpty(Fullnentry.Text))
            {
                DisplayAlert("Alert", "Fill the data", "OK;");
            }
            else if (String.IsNullOrEmpty(Emailnentry.Text))
            {
                DisplayAlert("Alert", "Fill the data", "OK;");
            }
            else if (String.IsNullOrEmpty(Phonenentry.Text))
            {
                DisplayAlert("Alert", "Fill the data", "OK;");
            }
            else if (String.IsNullOrEmpty(Addressnentry.Text))
            {
                DisplayAlert("Alert", "Fill the data", "OK;");
            }
            else
            {
                MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
                koneksi.Open();
                MySqlCommand cmd = new MySqlCommand("insert into user(username,password,fullname,email,phone_number,address) values('" + Userentry.Text +"','" + Passwentry.Text +"','" + Fullnentry.Text +"','" + Emailnentry.Text +"','" + Phonenentry.Text +"','" + Addressnentry.Text +"')", koneksi);
                var rd = cmd.ExecuteReaderAsync();
            
                koneksi.Close();
                DisplayAlert("Info", "Register Succesfuly", "OK");

                Userentry.Text = null;
                Passwentry.Text = null;
                Fullnentry.Text = null;
                Emailnentry.Text = null;
                Phonenentry.Text = null;
                Addressnentry.Text = null;
            }


        }
    }
}