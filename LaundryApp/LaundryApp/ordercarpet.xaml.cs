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
	public partial class ordercarpet : ContentPage
	{
		public ordercarpet ()
		{
			InitializeComponent ();
		}

        private void Btnpay_Clicked(object sender, EventArgs e)
        {
            string type = "carpet";
            Application.Current.Properties["jmlk"] = lstepper.Text;
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            MySqlCommand cmd = new MySqlCommand("select karpet from jenis_service where type = @tipe ", koneksi);
            cmd.Parameters.AddWithValue("tipe", type);
            var rd = cmd.ExecuteReader();
            rd.Read();
            string karpet = rd["karpet"].ToString();
            string jumlahk = $"{Application.Current.Properties["jmlk"].ToString()}";
            rd.Close();
            int k = Convert.ToInt32(karpet);
            int jk = Convert.ToInt32(jumlahk);
            int kloso = k * jk;
            int total = kloso;

            string id = $"{Application.Current.Properties["userid"].ToString()}";
            int ids = Convert.ToInt32(id);
            MySqlCommand cmd2 = new MySqlCommand("insert into pemesanan(id_user,type,karpet, total) values ('"+ids+"','" + type + "','" + kloso + "','" + total + "')", koneksi);
            var rd2 = cmd2.ExecuteReaderAsync();

            koneksi.Clone();

            Navigation.PushAsync(new PaymentCarpet());
        }

        private void Btnhome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new homepage());
        }

        private void Btnakun_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new accpage());
        }
    }
}