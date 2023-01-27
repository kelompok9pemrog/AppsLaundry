using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaundryApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Payment : ContentPage
	{
        public Payment()
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
            string jumlahs = $"{Application.Current.Properties["jmls"].ToString()}";
            string jumlahtr = $"{Application.Current.Properties["jmltr"].ToString()}";
            string jumlahts = $"{Application.Current.Properties["jmlts"].ToString()}";
            string jumlahtw = $"{Application.Current.Properties["jmltw"].ToString()}";
            Labelit.Text = jumlahs;
            Labelitro.Text = jumlahtr;
            Labelits.Text = jumlahts;
            Labelitow.Text = jumlahtw;
            int js = Convert.ToInt32(jumlahs);
            int jtr = Convert.ToInt32(jumlahtr);
            int jts = Convert.ToInt32(jumlahts);
            int jtw = Convert.ToInt32(jumlahtw);
            int totalitem = js + jtr + jts + jtw;
            Labelitem.Text = totalitem.ToString();
            string id = $"{Application.Current.Properties["userid"].ToString()}";

            MySqlCommand cmd2 = new MySqlCommand("select id_pesan,type,shirt,trousers,tshirt,towel,total from pemesanan where id_user=@aidi order by id_pesan desc limit 1", koneksi);
            cmd2.Parameters.AddWithValue("aidi", id);
            var reader2 = cmd2.ExecuteReader();
            reader2.Read();
            nopesan.Text = reader2["id_pesan"].ToString();
            type.Text = reader2["type"].ToString();
            pricesh.Text = reader2["shirt"].ToString();
            pricetr.Text = reader2["trousers"].ToString();
            pricetsh.Text = reader2["tshirt"].ToString();
            pricetw.Text = reader2["towel"].ToString();
            total.Text = reader2["total"].ToString();
            string totalbayar = reader2["total"].ToString();
            int totalbyr = Convert.ToInt32(totalbayar);
            Application.Current.Properties["totol"] = totalbyr;
            reader2.Close();
        }
        private void Btnpay_Clicked(object sender, EventArgs e)
        {
            MySqlConnection koneksi = new MySqlConnection(Properties.Resources.db_app);
            koneksi.Open();
            string tutul = $"{Application.Current.Properties["totol"].ToString()}";
            int tetel = Convert.ToInt32(tutul);
            string id = $"{Application.Current.Properties["userid"].ToString()}";
            string saldoawal = $"{Application.Current.Properties["saldousr"].ToString()}";
            int saldoawl = Convert.ToInt32(saldoawal);
            int sisa = 0;
            string jenis = $"{Application.Current.Properties["jenis"].ToString()}";
            string nomor = nopesan.Text.ToString();
            // if (saldoawl >= tetel)
            {
               // sisa = saldoawl - tetel;
                //MySqlCommand cmd3 = new MySqlCommand("insert into pembayaran(id_pesan,id_jenis,total,sisasaldo) values ('"+nomor+"','"+jenis+"','"+total.Text+"','"+sisa+"')", koneksi);
                //var rr = cmd3.ExecuteReader();
                //rr.Read();
                //rr.Close();
                //MySqlCommand cmd5 = new MySqlCommand("update saldo set [saldo]= '"+sisa+"' where id = @ida ", koneksi);
                //cmd5.Parameters.AddWithValue("ida", id);
                //var rr2 = cmd5.ExecuteReader();
                //rr2.Read();
                //rr2.Close();
            }
           // else
            {
               // DisplayAlert("Warning", "Saldo Anda kurang, batalkan pesanan dan isi saldo!", "OK");
                //MySqlCommand cmd4 = new MySqlCommand("delete from pemesanan where id_user = @aidi order by id_pesan desc limit 1", koneksi);
                //cmd4.Parameters.AddWithValue("aidi", id);
                //var rr1 = cmd4.ExecuteReader();
                //rr1.Read();
                //rr1.Close();
                Navigation.PushAsync(new homepage());
            }
            Navigation.PushAsync(new Success());
        }

        private void EntryDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            EntryDate.Date = new DateTime();
        }
    }
}