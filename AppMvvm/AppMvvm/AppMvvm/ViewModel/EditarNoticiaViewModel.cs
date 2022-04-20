using AppMvvm.Infrastructure;
using AppMvvm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppMvvm.ViewModel
{
    public class EditarNoticiaViewModel: INotifyPropertyChanged
    {
        private int _noticiaId;
        public int NoticiaId
        {
            get { return _noticiaId; }
            set { _noticiaId = value;NotifyPropertyChanged(nameof(NoticiaId)); }
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


        private readonly IAlmacen _almacen;
        private Noticia _noticiaOrigen;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command GuardarCommand { get; set; }
        public Command CancelarCommand { get; set; }
        public EditarNoticiaViewModel(Noticia origen, IAlmacen almacen)
        {
            _noticiaOrigen = origen;
            _almacen = almacen;
            GuardarCommand = new Command(Guardar);//, DatosValidos);
            CancelarCommand = new Command(Cancelar);
        }
        //private bool DatosValidos()
        //{
        //    return !string.IsNullOrEmpty(Titulo) && !string.IsNullOrEmpty(Cuerpo);
        //}
        private void Guardar()
        {
            var nuevaNoticia = new Noticia
            {
                Cuerpo = this.Cuerpo,
                Titulo = this.Titulo,
                Fecha = DateTime.Now
            };
            nuevaNoticia.Id = _almacen.ConsultarNoticias().Count() + 1;
            _almacen.AgregarNoticia(nuevaNoticia);
            App.Current.MainPage.Navigation.PopAsync();
        }
        private void Cancelar()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
