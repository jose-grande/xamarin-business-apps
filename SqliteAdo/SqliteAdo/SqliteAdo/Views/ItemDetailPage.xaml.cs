using SqliteAdo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SqliteAdo.Views
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