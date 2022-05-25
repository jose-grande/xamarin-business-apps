using NewsRestApp.Model;
using NewsRestApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsRestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaNoticiaPage : ContentPage
    {
        public NuevaNoticiaPage(Noticia noticia)
        {
            InitializeComponent();
            BindingContext = new NuevaNoticiaViewModel(noticia);
        }
    }
}