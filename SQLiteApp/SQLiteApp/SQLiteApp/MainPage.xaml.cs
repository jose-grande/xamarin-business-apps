using SQLiteApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void VerNoticiasButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoticiasPage());
        }

        private async void AgregarNoticiaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarNoticiaPage());
        }
    }
}
