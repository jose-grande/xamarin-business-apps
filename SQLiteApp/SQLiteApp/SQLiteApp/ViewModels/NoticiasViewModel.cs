using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SQLiteApp.ViewModels
{
    public class NoticiasViewModel: ViewModelBase
    {
        public ObservableCollection<Noticia> Noticias { get; set; }
        public Command RefrescarDatosCommand { get; set; }

        public NoticiasViewModel()
        {
            RefrescarDatosCommand = new Command(RefrescarDatos);
            Noticias = new ObservableCollection<Noticia>();
            TituloPagina = "Noticias";
        }
        private async void RefrescarDatos()
        {
            Noticias.Clear();
            var resultado = await App.Database.ConsultarAsync();
            foreach (var noticia in resultado)
            {
                Noticias.Add(noticia);
            }
        }
    }
}
