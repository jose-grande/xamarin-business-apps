using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewsWebApp.DataTransferObjects
{
    public class CategoriaView
    {
        public Guid CategoriaId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Nombre { get; set; }
    }
}
