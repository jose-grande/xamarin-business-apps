using AppMvvm.Infrastructure;
using AppMvvm.Model;
using AppMvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AppMvvm.ViewModel
{
    //Clean Code
    public class NoticiasViewModel
    {
        private IAlmacen _almacen;
        public ObservableCollection<Noticia> Noticias { get; set; }
        public Command CargarNoticiasCommand { get; set; }
        public Command<Noticia> VerNoticiaCommand { get; set; }
        public Command NuevaNoticiaCommand { get; set; }
        public Command VerCategoriasCommand { get; set; }
        public string Titulo { get; set; }
        public NoticiasViewModel()
        {
            Titulo = "Imagina News";
            _almacen = new Almacen();
            CargarNoticiasCommand = new Command(CargarNoticias);
            Noticias = new ObservableCollection<Noticia>();
            VerNoticiaCommand = new Command<Noticia>(VerNoticia);
            NuevaNoticiaCommand = new Command(AgregarNoticia);
            VerCategoriasCommand = new Command(VerCategorias);
        }
        public void CargarNoticias()
        {
            Noticias.Clear();
            var nuevasNoticias = _almacen.ConsultarNoticias();
            foreach (Noticia item in nuevasNoticias)
            {
                Noticias.Add(item);
            }
        }
        public void VerNoticia(Noticia param)
        {
            var noticia = param as Noticia;
            App.Current.MainPage.Navigation.PushAsync(new DetallesNoticiaView(noticia.Id, _almacen));
        }
        public void AgregarNoticia()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarNoticiaView(_almacen));
        }
        public void VerCategorias()
        {
            App.Current.MainPage.Navigation.PushAsync(new CategoriasViewPage(_almacen));
        }
    }
}
