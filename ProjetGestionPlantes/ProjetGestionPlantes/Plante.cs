/*
Classe Plante qui stockera les données relatives à chaque plante 
 */
using System;
using SQLite;

namespace ProjetGestionPlantes
{
    public class Plante
    {
        [PrimaryKey, AutoIncrement]
        public int ID_PLANTE { get; set; }
        public string Nom { get; set; }
        public string Notes { get; set; }
        public DateTime dernierArrosage { get; set; }
        public int IdEspece { get; set; }
    }
}