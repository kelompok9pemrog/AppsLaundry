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
    public partial class PaymentCarpet : ContentPage
    {
        public PaymentCarpet()
        {
            InitializeComponent(); 
            string userinfo = $"{Application.Current.Properties["UserInfo"].ToString()}";
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            MySqlCommand cmd1 = new MySqlCommand("select address from user where username=@usrn", koneksi);
            cmd1.Parameters.AddWithValue("usrn", userinfo);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                Labeladdress.Text = reader1["address"].ToString();
            }
            reader1.Close();
            string jumlahk = $"{Application.Current.Properties["jmlk"].ToString()}";
            Labelit.Text = jumlahk;
            Labelitcar.Text = jumlahk;
            int jk = Convert.ToInt32(jumlahk);
            int totalitem = jk;
            Labelitcar.Text = totalitem.ToString();
            string id = $"{Application.Current.Properties["userid"].ToString()}";

            MySqlCommand cmd2 = new MySqlCommand("select id_pesan,type,karpet,total from pemesanan where id_user=@aidi order by id_pesan desc limit 1", koneksi);
            cmd2.Parameters.AddWithValue("aidi", id);
            var reader2 = cmd2.ExecuteReader();
            reader2.Read();
            nopesan.Text = reader2["id_pesan"].ToString();
            type.Text = reader2["type"].ToString();
            pricecarpet.Text = reader2["karpet"].ToString();
            total.Text = reader2["total"].ToString();
        }

        private void Btnpay_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Success());
        }
    }
}