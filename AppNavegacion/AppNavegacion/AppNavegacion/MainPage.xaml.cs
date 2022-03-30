using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppNavegacion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AndroidInfoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AndroidPage(NombreEntry.Text));
        }
        private void iOSInfoButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void FeaturesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeaturesPage());
        }
    }
}
