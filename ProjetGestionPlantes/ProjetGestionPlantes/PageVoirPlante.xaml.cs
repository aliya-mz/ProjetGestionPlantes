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
    public partial class PageVoirPlante : ContentPage
    {
        static Plante plante;

        public PageVoirPlante(Plante planteSelectionnee)
        {
            InitializeComponent();
            plante = planteSelectionnee;

            Console.WriteLine(plante.ID_PLANTE);

            //Récupère l'id de la plante et le définit comme la valeur du QR Code
            zxingQrCode.BarcodeValue = Convert.ToString(plante.ID_PLANTE);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AfficherInfosPlante(plante);
        }

        private void OnClickReturn(object sender, EventArgs e)
        {
            //retourner sur la page d'accueil
            ((App)App.Current).ChangeScreen(new MainPage());
        }

        async void OnClickSaveInfo(object sender, EventArgs args)
        {
            plante.Notes = entryNote.Text;
            //mise à jour des notes la plante dans la BD
            await App.Database.UpdatePlanteInfos(plante);
        }

        async void OnClickArroser(object sender, EventArgs args)
        {
            plante.dernierArrosage = DateTime.Now;

            //mise à jour du dernier arrosage de la plante dans la BD
            await App.Database.UpdatePlanteInfos(plante);
        }

        async void AfficherInfosPlante(Plante Plante)
        {
            //récupérer l'espèce de la plante (nom de l'espèce en fonction de son id)
            List<Espece> especes = new List<Espece>();
            especes.AddRange(await App.Database.GetEspeceAsync());

            string nomEspece = "";
            //trouver dans la liste l'espèce dont l'id correspond
            foreach (Espece espece in especes)
            {
                if (espece.ID_ESPECE == plante.IdEspece)
                {
                    nomEspece = espece.NomEspece.ToString();
                }
            }

            //afficher les informations
            lblNomEspece.Text = plante.Nom.ToString() + ", " + nomEspece;
            entryInfo.Text = plante.dernierArrosage.ToString();
            entryNote.Text = plante.Notes.ToString();
        }
    }
}