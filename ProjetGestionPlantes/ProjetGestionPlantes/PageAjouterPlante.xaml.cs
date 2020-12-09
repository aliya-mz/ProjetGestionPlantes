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
            entryNom.Text = entryNotes.Text = string.Empty;
            //remplir la liste déroulante
            FillListEspeces();
        }

        async void FillListEspeces()
        {
            //récupérer la liste des espèces
            List<Espece> especes = new List<Espece>();
            especes.AddRange(await App.Database.GetEspeceAsync());

            //remplir la liste déroulante
            foreach (Espece espece in especes)
            {
                //pickerEspece.Items.Add(espece.ID_ESPECE + "-" + espece.NomEspece);

                ////pré-sélectionner le premier élément
                //pickerEspece.SelectedIndex = 1;
            }
        }

        async void OnClickCreate(object sender, EventArgs e)
        {
            //si les champs ont bien été remplis
            if (!string.IsNullOrWhiteSpace(entryNom.Text))
            {
                //Ajouter une plante vec les propriétés entrées dans le formulaire
                await App.Database.SavePlanteAsync(new Plante
                {
                    Nom = entryNom.Text,
                    Notes = entryNotes.Text,
                    dernierArrosage = DateTime.Now,
                    //récupère l'identifiant de l'espèce sélectionnée
                    //IdEspece = int.Parse((pickerEspece.Items[pickerEspece.SelectedIndex].Split('-'))[0]),
                });

                // retourner sur la page d'accueil
                ((App)App.Current).ChangeScreen(new MainPage());
            }
        }
    }
}