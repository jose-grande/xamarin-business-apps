using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsWebApp.DataAccess
{
    [Table("Categorias")]
    public class Categoria: Audit
    {
        [Key]
        public Guid CategoriaId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Nombre { get; set; }
        public ICollection<Noticia> Noticias { get; set; } = new List<Noticia>();
    }
}
