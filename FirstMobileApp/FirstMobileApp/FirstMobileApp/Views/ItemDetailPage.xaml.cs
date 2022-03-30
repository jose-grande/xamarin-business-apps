using FirstMobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FirstMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}