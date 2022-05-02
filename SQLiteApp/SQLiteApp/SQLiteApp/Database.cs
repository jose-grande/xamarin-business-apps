using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteApp.Model;

namespace SQLiteApp
{
    public class Database
    {
        SQLiteAsyncConnection _connection;
        public Database(string databasePath)
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            _connection.CreateTableAsync<Noticia>().Wait();
        }
        public Task<List<Noticia>> ConsultarAsync()
        {
            return _connection.Table<Noticia>().ToListAsync();
        }
        public Task<int> AgregarAsync(Noticia noticia)
        {
            return _connection.InsertAsync(noticia);
        }
    }
}
