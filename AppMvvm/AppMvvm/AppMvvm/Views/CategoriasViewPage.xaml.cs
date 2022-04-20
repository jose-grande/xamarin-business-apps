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
    public partial class CategoriasViewPage : ContentPage
    {
        private readonly IAlmacen almacen;

        public CategoriasViewPage(IAlmacen almacen)
        {
            InitializeComponent();
            BindingContext = new CategoriasViewModel(almacen);
            this.almacen = almacen;
        }
    }
}