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
    public partial class AndroidDetailPage : ContentPage
    {
        public AndroidDetailPage()
        {
            InitializeComponent();
        }

        private async void GoHomeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}