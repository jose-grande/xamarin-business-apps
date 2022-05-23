using NewsRestApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NewsRestApp.ViewModel
{
    public class NuevaNoticiaViewModel: ViewModelBase
    {
        private Guid _noticiaId;
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
        private DateTime _fechaPublicacion;

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; NotifyPropertyChanged(nameof(FechaPublicacion)); }
        }

        public Command GuardarCommand { get; set; }
        public ObservableCollection<Categoria> Categorias { get; set; }
        public NuevaNoticiaViewModel()
        {
            Title = "Nueva Noticia";
            GuardarCommand = new Command(Guardar);
            _noticiaId = Guid.NewGuid();
            this.FechaPublicacion = DateTime.Now;
            Categorias = new ObservableCollection<Categoria>();
            RefrescarCategorias();
        }
        public void Guardar()
        {
            var noticia = new Noticia
            {
                NoticiaId = _noticiaId,
                Titulo = Titulo,
                Cuerpo = Cuerpo,
                FechaPublicacion = FechaPublicacion,
                CategoriaId = Guid.Parse("566EF8EF-7DF3-4C34-BBBC-F58F72F729B9")
            };
            App.Service.AgregarNoticia(noticia);
        }
        public void RefrescarCategorias()
        {
            var result = App.Service.ConsultarCategorias();
            Categorias.Clear();
            foreach (var item in result)
            {
                Categorias.Add(item);
            }
        }
    }
}
