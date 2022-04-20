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
    public partial class EditarNoticiaView : ContentPage
    {
        private readonly IAlmacen almacen;

        public EditarNoticiaView(IAlmacen almacen)
        {
            InitializeComponent();
            this.almacen = almacen;
            BindingContext = new EditarNoticiaViewModel(null, almacen);
        }
    }
}