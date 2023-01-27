using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaundryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class accpage : ContentPage
    {
        public accpage()
        {
            InitializeComponent();
            string userinfo = $"{Application.Current.Properties["UserInfo"].ToString()}";
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            MySqlCommand cmd1 = new MySqlCommand("select username,email,phone_number,address,fullname, password from user where username=@usrn", koneksi);
            cmd1.Parameters.AddWithValue("usrn", userinfo);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                labelpass.Text = reader1["password"].ToString();
                labelfull.Text = reader1["fullname"].ToString();
                labeladdr.Text = reader1["address"].ToString();
                labelmail.Text = reader1["email"].ToString();
                labelphone.Text = reader1["phone_number"].ToString();
                labelusn.Text = reader1["username"].ToString();
            }
        }

        private void Btnhome_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new homepage());
        }

        private void Btnorder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new History_Page());
        }
    }
}