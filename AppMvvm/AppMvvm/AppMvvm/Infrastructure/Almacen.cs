using AppMvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMvvm.Infrastructure
{
    public class Almacen: IAlmacen
    {
        private List<Noticia> _noticias;
        private List<Categoria> _categorias;
        public Almacen()
        {
            _noticias = new List<Noticia>();
            _noticias.Add(new Noticia { Id = 1, Titulo = "Microsoft MAUI", Cuerpo = "Proximo lanzamiento de Microsoft MAUI", Fecha = DateTime.Now });
            _noticias.Add(new Noticia { Id = 2, Titulo = "Kubernetes CRI", Cuerpo = "Kubernetes planea reemplazar Docker por CRI(Container Runtime Interface)", Fecha = DateTime.Now });
            _noticias.Add(new Noticia { Id = 3, Titulo = "PowerShell Para Ubuntu", Cuerpo = "Sabías que puedes utilizar PowerShell en Ubuntu?", Fecha = DateTime.Now });

            _categorias = new List<Categoria>();
            _categorias.Add(new Categoria { CategoriaId = 1, Nombre = "Tecnología" });
            _categorias.Add(new Categoria { CategoriaId = 2, Nombre = "Microsoft" });
            _categorias.Add(new Categoria { CategoriaId = 3, Nombre = "Apple" });
            _categorias.Add(new Categoria { CategoriaId = 4, Nombre = "Google" });
        }
        public IEnumerable<Noticia> ConsultarNoticias()
        {
            return _noticias;
        }
        public Noticia ConsultarNoticia(int id)
        {
            return _noticias.FirstOrDefault(c=> c.Id==id);
        }
        public void AgregarNoticia(Noticia noticia)
        {
            _noticias.Add(noticia);
        }
        public void ModificarNoticia(int id, string titulo, string cuerpo, DateTime fecha)
        {
            var source = _noticias.FirstOrDefault(c => c.Id == id);
            source.Titulo = titulo;
            source.Cuerpo = cuerpo;
            source.Fecha = fecha;
        }
        public void EliminarNoticia(int id)
        {
            var source = _noticias.FirstOrDefault(c => c.Id == id);
            _noticias.Remove(source);
        }


        public IEnumerable<Categoria> ConsultarCategorias()
        {
            return _categorias;
        }
        public Categoria ConsultarCategoria(int id)
        {
            return _categorias.FirstOrDefault(c => c.CategoriaId == id);
        }
        public void AgregarCategoria(Categoria categoria)
        {
            _categorias.Add(categoria);
        }
        public void ModificarCategoria(int id, string nombre)
        {
            var source = _categorias.FirstOrDefault(c => c.CategoriaId == id);
            source.Nombre = nombre;
        }
        public void EliminarCategoria(int id)
        {
            var source = _categorias.FirstOrDefault(c => c.CategoriaId == id);
            _categorias.Remove(source);
        }
    }
}
