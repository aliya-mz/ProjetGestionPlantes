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
            _database.CreateTableAsync<Espece>().Wait();
        }

        //gestion de la table Plante
        public Task<List<Plante>> GetPlanteAsync()
        {
            return _database.Table<Plante>().ToListAsync();
        }

        public Task<int> SavePlanteAsync(Plante plante)
        {
            return _database.InsertAsync(plante);
        }

        //gestion de la table Espece
        public Task<List<Espece>> GetEspeceAsync()
        {
            return _database.Table<Espece>().ToListAsync();
        }

        public Task<int> SaveEspeceAsync(Espece espece)
        {
            return _database.InsertAsync(espece);
        }
    }
}
