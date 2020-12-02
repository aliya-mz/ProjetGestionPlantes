using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGestionPlantes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAjouterPlante : ContentPage
    {
        public PageAjouterPlante()
        {
            InitializeComponent();
        }        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //vider les champs
            entryNom.Text = entryNotes.Text = entryEspece.Text = string.Empty;
        }

        async void OnClickCreate(object sender, EventArgs e)
        {
            //si les champs ont bien été remplis
            if (!string.IsNullOrWhiteSpace(entryNom.Text) && !string.IsNullOrWhiteSpace(entryEspece.Text))
            {
                Console.WriteLine("ïf : ok");

                //Ajouter une plante vec les propriétés entrées dans le formulaire
                await App.Database.SavePlanteAsync(new Plante
                {
                    Nom = entryNom.Text,
                    Notes = entryNotes.Text,
                    dernierArrosage = DateTime.Now,
                    IdEspece = int.Parse(entryEspece.Text),
                });

                // retourner sur la page d'accueil
                ((App)App.Current).ChangeScreen(new MainPage());
            }
        }
    }
}