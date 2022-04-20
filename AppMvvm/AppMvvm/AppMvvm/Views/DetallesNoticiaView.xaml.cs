using AppMvvm.Infrastructure;
using AppMvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesNoticiaView : ContentPage
    {
        public DetallesNoticiaView(int id, IAlmacen almacen)
        {
            InitializeComponent();
            BindingContext = new DetallesNoticiaViewModel(id, almacen);
        }
    }
}