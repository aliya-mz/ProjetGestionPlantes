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

            MainPage = new MainPage();
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

//A METTRE DANS PAGE_AJOUTER_PLANTE.XAML.CS

//async void OnClickCreate(object sender, EventArgs e)
//{
//    if (!string.IsNullOrWhiteSpace(entryNom.Text) && !string.IsNullOrWhiteSpace(entryNotes.Text) && !string.IsNullOrWhiteSpace(entryEspece.Text))
//    {
//        //Ajout d'une plante avec les propriétés entrées dans le formulaire
//        await App.Database.SavePlanteAsync(new Plante
//        {
//            Nom = entryNom.Text,
//            Notes = int.Parse(entryNotes.Text),
//            IdEspece = int.Parse(entryEspece.Text),
//        });

//        //vider les champs
//        entryNom.Text = entryNotes.Text = entryEspece.Text = string.Empty;
//    }
//}

//A METTRE DANS MAIN_PAGE.XAML.CS