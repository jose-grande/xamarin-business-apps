using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlCollections.Model;

namespace XamlCollections
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Noticia> noticias;
        public MainPage()
        {
            noticias = new ObservableCollection<Noticia>();
            for (int i = 0; i < 5; i++)
            {
                int numNoticia = i + 1;
                noticias.Add(new Noticia
                {
                    Titulo = $"Noticia {numNoticia}",
                    Cuerpo = $"Este es el cuerpo de la noticia {numNoticia}",
                    Fecha = DateTime.Now
                });
            }
            InitializeComponent();
            NoticiasListView.ItemsSource = noticias;
        }

        private void NuevaNoticiaButton_Clicked(object sender, EventArgs e)
        {
            var numNoticia = noticias.Count + 1;
            var noticia = new Noticia
            {
                Titulo = $"Noticia {numNoticia}",
                Cuerpo = $"Este es el cuerpo de la noticia {numNoticia}",
                Fecha = DateTime.Now
            };
            noticias.Add(noticia);
        }
    }
}
