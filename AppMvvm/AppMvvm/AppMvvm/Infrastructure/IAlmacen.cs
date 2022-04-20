using AppMvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMvvm.Infrastructure
{
    public interface IAlmacen
    {
        #region Noticias
        IEnumerable<Noticia> ConsultarNoticias();
        Noticia ConsultarNoticia(int id);
        void AgregarNoticia(Noticia noticia);
        void ModificarNoticia(int id, string titulo, string cuerpo, DateTime fecha);
        void EliminarNoticia(int id);
        #endregion

        #region Categorias
        IEnumerable<Categoria> ConsultarCategorias();
        Categoria ConsultarCategoria(int id);
        void AgregarCategoria(Categoria categoria);
        void ModificarCategoria(int id, string nombre);
        void EliminarCategoria(int id);

        #endregion
    }
}
