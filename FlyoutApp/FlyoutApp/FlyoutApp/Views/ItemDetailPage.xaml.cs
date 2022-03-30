using FlyoutApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FlyoutApp.Views
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