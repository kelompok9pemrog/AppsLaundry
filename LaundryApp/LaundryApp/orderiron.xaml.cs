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
	public partial class orderiron : ContentPage
	{
		public orderiron ()
		{
			InitializeComponent ();
		}

        private void Btnpay_Clicked(object sender, EventArgs e)
        {
            string type = "ironing";
            Application.Current.Properties["jmls"] = lstepper.Text;
            Application.Current.Properties["jmltr"] = lstep.Text;
            Application.Current.Properties["jmlts"] = lste.Text;
            Application.Current.Properties["jmltw"] = lper.Text;
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            MySqlCommand cmd = new MySqlCommand("select shirt,tshirt,trousers,towel from jenis_service where type = @tipe ", koneksi);
            cmd.Parameters.AddWithValue("tipe", type);
            var rd = cmd.ExecuteReader();
            rd.Read();
            string shirt = rd["shirt"].ToString();
            string trousers = rd["trousers"].ToString();
            string tshirt = rd["tshirt"].ToString();
            string towel = rd["towel"].ToString();
            string jumlahs = $"{Application.Current.Properties["jmls"].ToString()}";
            string jumlahtr = $"{Application.Current.Properties["jmltr"].ToString()}";
            string jumlahts = $"{Application.Current.Properties["jmlts"].ToString()}";
            string jumlahtw = $"{Application.Current.Properties["jmltw"].ToString()}";
            rd.Close();
            int s = Convert.ToInt32(shirt);
            int tr = Convert.ToInt32(trousers);
            int ts = Convert.ToInt32(tshirt);
            int tw = Convert.ToInt32(towel);
            int js = Convert.ToInt32(jumlahs);
            int jtr = Convert.ToInt32(jumlahtr);
            int jts = Convert.ToInt32(jumlahts);
            int jtw = Convert.ToInt32(jumlahtw);
            int baju = s * js;
            int katok = tr * jtr;
            int kaos = ts * jts;
            int handuk = tw * jtw;
            int total = baju + katok + kaos + handuk;

            string id = $"{Application.Current.Properties["userid"].ToString()}";
            int ids = Convert.ToInt32(id);
            MySqlCommand cmd2 = new MySqlCommand("insert into pemesanan(id_user,type,shirt,trousers,tshirt,towel, total) values ('" + ids + "','" + type + "','" + baju + "','" + katok + "','" + kaos + "','" + handuk + "','" + total + "')", koneksi);
            var rd2 = cmd2.ExecuteReaderAsync();

            koneksi.Clone();
            Navigation.PushAsync(new Payment());
        }


    }
}