using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteApp.ViewModels
{
    public class EditarNoticiaViewModel : ViewModelBase
    {
        private Guid _noticiaId;
        public Guid NoticiaId
        {
            get { return _noticiaId; }
            set { _noticiaId = value; NotifyPropertyChanged(nameof(NoticiaId)); }
        }
        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; NotifyPropertyChanged(nameof(Titulo)); }
        }
        private string _cuerpo;
        public string Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; NotifyPropertyChanged(nameof(Cuerpo)); }
        }
        

        public Command GuardarCommand { get; set; }
        public EditarNoticiaViewModel()
        {
            NoticiaId = Guid.NewGuid();
            GuardarCommand = new Command(Guardar);
            TituloPagina = "Nueva Noticia";
        }
        private async void Guardar()
        {
            Noticia noticia = new Noticia()
            {
                NoticiaId = NoticiaId,
                Cuerpo = Cuerpo,
                Titulo = Titulo,
                FechaPublicacion = DateTime.Now
            };
            await App.Database.AgregarAsync(noticia);
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
