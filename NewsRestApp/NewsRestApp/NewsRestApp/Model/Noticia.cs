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
        public DateTime FechaPublicacion { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
