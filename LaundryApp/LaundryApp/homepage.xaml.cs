using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaundryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class homepage : ContentPage
    {
        public homepage()
        {
            InitializeComponent();
            MyName.Text = $"{Application.Current.Properties["UserInfo"].ToString()}";
            string usr = $"{Application.Current.Properties["UserInfo"].ToString()}";
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            MySqlCommand cmd = new MySqlCommand("select id_user from user where username = @us", koneksi);
            cmd.Parameters.AddWithValue("us", usr);
            var rd = cmd.ExecuteReader();
            rd.Read();
            string iduser = rd["id_user"].ToString();
            Application.Current.Properties["userid"] = iduser;
            rd.Close();

            string id = $"{Application.Current.Properties["userid"].ToString()}";
            int ids = Convert.ToInt32(id);
            MySqlCommand cmd2 = new MySqlCommand("select saldo from saldo where id_user=@aidi", koneksi);
            cmd2.Parameters.AddWithValue("aidi", ids);
            var reader2 = cmd2.ExecuteReader();
            reader2.Read();
            string saldo = reader2["saldo"].ToString();
            Lblsaldo.Text = saldo;
            Application.Current.Properties["saldousr"] = saldo;
        }
        protected virtual bool OnBackButtonPressed() { return false; }
        private void Btnpesanan_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new History_Page());
        }

        private void Btntextorder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new History_Page());
        }

        private void BtnWash_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new orderpage());
        }

        private void BtnDry_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new orderdry());
        }

        private void BtnIron_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new orderiron());
        }

        private void BtnCarpet_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ordercarpet());
        }

        private void Btnakun_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new accpage());
        }
    }
}