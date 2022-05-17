using System;
using System.Collections.Generic;
using System.Text;

namespace NewsRestApp.Model
{
    public class Noticia
    {
        public Guid NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public string FechaPublicacion { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
