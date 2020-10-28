using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ProjetGestionPlantes
{    
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Plante>().Wait();
        }

        public Task<List<Plante>> GetPeopleAsync()
        {
            return _database.Table<Plante>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Plante plante)
        {
            return _database.InsertAsync(plante);
        }
    }
}
