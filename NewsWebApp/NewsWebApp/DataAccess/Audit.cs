using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.DataAccess
{
    public class Audit
    {
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
