using NewsRestApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsRestApp.Services
{
    public interface INewsWebService
    {
        List<Noticia> Consultar();
        void AgregarNoticia(Noticia noticia);
        void ModificarNoticia(Noticia noticia);
        List<Categoria> ConsultarCategorias();
    }
}
