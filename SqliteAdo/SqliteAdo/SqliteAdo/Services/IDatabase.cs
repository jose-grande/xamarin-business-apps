using SqliteAdo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAdo.Services
{
    public interface IDatabase
    {
        int Agregar(Noticia obj);
        int Actualizar(Noticia obj);
        int Eliminar(Guid id);
        Noticia Consultar(Guid id);
        IEnumerable<Noticia> Consultar();
    }
}
