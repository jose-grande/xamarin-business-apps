using Microsoft.Data.Sqlite;
using SqliteAdo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAdo.Services
{
    public class Database : IDatabase
    {
        private readonly string _databasePath;
        private readonly string connectionString;
        public Database(string databasePath)
        {
            this._databasePath = databasePath;
            this.connectionString = $"Data source={_databasePath}";
            Inicializar();
        }
        private void Inicializar()
        {
            

            if (!System.IO.File.Exists(_databasePath))
            {
                using(var connection = new SqliteConnection(connectionString))
                {
                    var createTableCommand = new SqliteCommand(SqlConstants.NoticiasCreateTable, connection);
                    
                    var noticia1Command = new SqliteCommand(
                        string.Format(SqlConstants.NoticiasInsert, 
                            Guid.NewGuid().ToString(),
                            "Noticia1",
                            "Cuerpo noticia 1", 
                            DateTime.Today.ToString("yyyy-MM-dd"))
                        );
                    noticia1Command.Connection = connection;
                    
                    var noticia2Command = new SqliteCommand(
                        string.Format(SqlConstants.NoticiasInsert,
                            Guid.NewGuid().ToString(),
                            "Noticia2",
                            "Cuerpo noticia 2",
                            DateTime.Today.ToString("yyyy-MM-dd"))
                        );
                    noticia2Command.Connection = connection;
                    
                    connection.Open();
                    
                    var result = createTableCommand.ExecuteNonQuery();
                    result = noticia1Command.ExecuteNonQuery();
                    result = noticia2Command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("El archivo de base de datos se encontró.");
                using (var connection = new SqliteConnection(connectionString))
                {
                    var command = new SqliteCommand(SqlConstants.NoticiasSelectAll, connection);
                    connection.Open();
                    SqliteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Titulo"]);
                        }
                    }
                    connection.Close();
                }
            }
        }
        public int Actualizar(Noticia obj)
        {
            throw new NotImplementedException();
        }

        public int Agregar(Noticia obj)
        {
            int result = 0;
            using(var connection=new SqliteConnection(connectionString))
            {
                var insertText = string.Format(SqlConstants.NoticiasInsert,
                    obj.NoticiaId.ToString(),
                    obj.Titulo,
                    obj.Cuerpo,
                    obj.FechaPublicacion.ToString("yyyy-MM-dd"));
                var command = new SqliteCommand(insertText, connection);
                connection.Open();
                result =command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }

        public Noticia Consultar(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Noticia> Consultar()
        {
            List<Noticia> result = new List<Noticia>();
            using(var connection=new SqliteConnection(connectionString))
            {
                var command = new SqliteCommand(SqlConstants.NoticiasSelectAll, connection);
                SqliteDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var noticia = new Noticia
                        {
                            NoticiaId= Guid.Parse(reader.GetString(0)),
                            Titulo=reader.GetString(1),
                            Cuerpo=reader.GetString(2),
                            FechaPublicacion=DateTime.Parse(reader.GetString(3))
                        };
                        result.Add(noticia);
                    }
                }
            }
            return result;
        }

        public int Eliminar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
