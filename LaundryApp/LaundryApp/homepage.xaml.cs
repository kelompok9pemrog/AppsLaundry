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
    public partial class homepage : ContentPage
    {
        public homepage()
        {
            InitializeComponent();
            MyName.Text = $"Hello { Application.Current.Properties["Name"].ToString()}";
        }
        private void Btnpesanan_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new orderpage());
        }

        private void Btntextorder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new orderpage());
        }
    }
}