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
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
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
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
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

//        //enregistrer les données dans une listview (non existante pour le moment)
//        //listView.ItemsSource = await App.Database.GetPeopleAsync();
//    }
//}