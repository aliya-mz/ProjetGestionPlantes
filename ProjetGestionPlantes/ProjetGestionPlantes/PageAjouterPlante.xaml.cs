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

        //private void OnClickCreate(object sender, EventArgs args)
        //{
        //}

        async void OnClickCreate(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(entryNom.Text) && !string.IsNullOrWhiteSpace(entryNotes.Text) && !string.IsNullOrWhiteSpace(entryEspece.Text))
            {
                //test
                //    Button button = (Button)sender;
                //    button.Text = "réussi";
                //    btnCreatePlante.BackgroundColor = Color.Blue;

                //Ajout d'une plante avec les propriétés entrées dans le formulaire
                await App.Database.SavePlanteAsync(new Plante
                {
                    Nom = entryNom.Text,
                    Notes = entryNotes.Text,
                    dernierArrosage = default,
                    IdEspece = int.Parse(entryEspece.Text),
                });

                //vider les champs
                entryNom.Text = entryNotes.Text = entryEspece.Text = string.Empty;
            }
        }
    }

}