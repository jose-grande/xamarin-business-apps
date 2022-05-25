using NewsRestApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NewsRestApp.ViewModel
{
    public class NuevaNoticiaViewModel: ViewModelBase
    {
        private string _titulo;
        private Noticia _noticia;

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

        private Categoria _categoriaSeleccionada;

        public Categoria CategoriaSeleccionada
        {
            get { return _categoriaSeleccionada; }
            set { _categoriaSeleccionada = value; }
        }


        public Command GuardarCommand { get; set; }
        public ObservableCollection<Categoria> Categorias { get; set; }
        public NuevaNoticiaViewModel(Noticia noticia)
        {
            
            GuardarCommand = new Command(Guardar);
            _noticia = noticia;
            Categorias = new ObservableCollection<Categoria>();
            RefrescarCategorias();

            if (_noticia.NoticiaId == Guid.Empty)
            {
                Title = "Nueva Noticia";
                this.FechaPublicacion = DateTime.Now;
            }
            else
            {
                Title = "Modificar Noticia";
                Titulo = noticia.Titulo;
                Cuerpo = noticia.Cuerpo;
                FechaPublicacion = noticia.FechaPublicacion;
                CategoriaSeleccionada = Categorias.FirstOrDefault(c => c.CategoriaId == noticia.CategoriaId);
            }
            
            
        }
        public void Guardar()
        {
            var noticia = new Noticia
            {
                NoticiaId = _noticia.NoticiaId,
                Titulo = Titulo,
                Cuerpo = Cuerpo,
                FechaPublicacion = FechaPublicacion,
                CategoriaId = CategoriaSeleccionada.CategoriaId
            };
            if (_noticia.NoticiaId == Guid.Empty)
            {
                App.Service.AgregarNoticia(noticia);
            }
            else
            {
                App.Service.ModificarNoticia(noticia);
            }
            
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
