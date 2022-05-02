using SQLiteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarNoticiaPage : ContentPage
    {
        public EditarNoticiaPage()
        {
            InitializeComponent();
            BindingContext = new EditarNoticiaViewModel();
        }

        private async void CancelarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}