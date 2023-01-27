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
	public partial class Success : ContentPage
	{
		public Success ()
		{
			InitializeComponent ();
		}

        private void Btnhome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new homepage());
        }
    }
}