using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNavegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AndroidPage : ContentPage
    {
        private string nombre;
        public AndroidPage(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            InfoLabel.Text = $"Bienvenido {nombre}!\n{InfoLabel.Text}";
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void DetailsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AndroidDetailPage());
        }
    }
}