using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteAdo.Services
{
    public class SqlConstants
    {
        public static readonly string NoticiasTableName = "Noticias";
        public static readonly string NoticiasCreateTable =
            @"CREATE TABLE [Noticias](
                NoticiaId text,
                Titulo text,
                Cuerpo text,
                FechaPublicacion text
            )";
        public static readonly string NoticiasInsert =
            @"INSERT INTO [Noticias](NoticiaId, Titulo, Cuerpo, FechaPublicacion)
            VALUES
            ('{0}','{1}','{2}','{3}')";
        public static readonly string NoticiasSelectAll = "SELECT  NoticiaId, Titulo, Cuerpo, FechaPublicacion FROM Noticias";
    }
}
