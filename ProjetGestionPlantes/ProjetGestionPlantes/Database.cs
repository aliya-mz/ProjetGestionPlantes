using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using System.Collections.ObjectModel;

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

        public Task<int> UpdatePlanteInfos(Plante plante)
        {
            if (plante.ID_PLANTE != 0)
            {
                return _database.UpdateAsync(plante);
            }
            else
            {
                return _database.InsertAsync(plante);
            }
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

        public Task<List<Espece>> GetEspeceByIdAsync(int id)
        {
            return _database.QueryAsync<Espece>("SELECT * FROM Espece WHERE ID_ESPECE = " + id);
        }
    }
}
