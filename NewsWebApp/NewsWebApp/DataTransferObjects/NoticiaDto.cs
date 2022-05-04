using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.DataTransferObjects
{
    public class NoticiaDto
    {
        public Guid NoticiaId { get; set; }
        [MaxLength(500)]
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cuerpo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
