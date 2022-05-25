using NewsRestApp.Model;
using NewsRestApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NewsRestApp.ViewModel
{
    public class NoticiasViewModel: ViewModelBase
    {
        public ObservableCollection<Noticia> Noticias { get; set; }
        public Command RefrescarCommand { get; set; }
        public Command NuevaNoticiaCommand { get; set; }
        public Command<Noticia> EditarNoticiaCommand { get; set; }
        public NoticiasViewModel()
        {
            Noticias = new ObservableCollection<Noticia>();
            RefrescarCommand = new Command(Refrescar);
            NuevaNoticiaCommand = new Command(NuevaNoticia);
            EditarNoticiaCommand = new Command<Noticia>(EditarNoticia);
            Title = "Noticias";
        }
        public void Refrescar()
        {
            IsBusy = true;
            Noticias.Clear();
            var result = App.Service.Consultar();
            foreach (var item in result)
            {
                Noticias.Add(item);
            }
            IsBusy = false;
        }
        public void NuevaNoticia()
        {
            App.Current.MainPage.Navigation.PushAsync(new NuevaNoticiaPage(new Noticia { NoticiaId=Guid.Empty}));
        }
        public void EditarNoticia(Noticia noticia)
        {
            App.Current.MainPage.Navigation.PushAsync(new NuevaNoticiaPage(noticia));
        }
    }
}
