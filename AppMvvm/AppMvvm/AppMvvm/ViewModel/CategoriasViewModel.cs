using AppMvvm.Infrastructure;
using AppMvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AppMvvm.ViewModel
{
    public class CategoriasViewModel
    {
        private IAlmacen _almacen;
        public ObservableCollection<Categoria> Categorias { get; set; }
        public Command RefrescarCommand { get; set; }
        public CategoriasViewModel(IAlmacen almacen)
        {
            _almacen = almacen;
            Categorias = new ObservableCollection<Categoria>();
            RefrescarCommand = new Command(Refrescar);
        }
        public void Refrescar()
        {
            Categorias.Clear();
            var resultado = _almacen.ConsultarCategorias();
            foreach (var item in resultado)
            {
                Categorias.Add(item);
            }
        }
    }
}
