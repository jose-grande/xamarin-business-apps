using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsWebApp.DataAccess
{
    [Table("Noticias")]
    public class Noticia: Audit
    {
        [Key]
        public Guid NoticiaId { get; set; }
        [MaxLength(500)]
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cuerpo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
