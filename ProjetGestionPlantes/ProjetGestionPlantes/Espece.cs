/*
Classe Espece qui stockera les données relatives à chaque espece
 */

using SQLite;

namespace ProjetGestionPlantes
{
    public class Espece
    {
        [PrimaryKey, AutoIncrement]
        public int ID_ESPECE { get; set; }
        public string NomEspece { get; set; }

        //nombre de jours recommandés entre deux arrosages
        public int FrequArrosage { get; set; }
    }
}