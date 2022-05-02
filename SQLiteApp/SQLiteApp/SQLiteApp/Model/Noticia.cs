using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteApp.Model
{
    [Table("Noticias")]
    public class Noticia
    {
        [PrimaryKey]
        public Guid NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
