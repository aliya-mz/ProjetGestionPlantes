using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace ProjetGestionPlantes
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                //si la BD n'a pas encore été créee
                if (database == null)
                {
                    //Créer la BD
                    //dbplantes.db3 est le fichier de la base de données locale
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbplantes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();  
            
            //créer la page racine de l'application
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MainPage();
        }

        /// <summary>
        /// Fonction qui permet de changer la page actuellement affichée.
        /// </summary>
        /// <param name="page">Page à afficher</param>
        public void ChangeScreen(Page page)
        {
            MainPage = page;
        }

        protected override void OnStart()
        {
            //Quand l'application démarre
        }

        protected override void OnSleep()
        {
            //Quand l'application est en veille
        }

        protected override void OnResume()
        {
            //Quand on revient sur l'application
        }
    }
}