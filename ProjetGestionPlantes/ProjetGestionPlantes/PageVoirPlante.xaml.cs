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
        static int idPlante;
        static Plante plante;

        public PageVoirPlante(int id_Plante)
        {
            InitializeComponent();
            idPlante = id_Plante;

            //Récupère l'id de la plante et le définit comme la valeur du QR Code
            zxingQrCode.BarcodeValue = Convert.ToString(idPlante);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AfficherInfosPlante(idPlante);
        }

        private void OnClickReturn(object sender, EventArgs e)
        {
            //retourner sur la page d'accueil
            ((App)App.Current).ChangeScreen(new MainPage());
        }

        private void OnClickSaveInfo(object sender, EventArgs args)
        {
            //mettre à jour l'enregistrement (les notes)            
            plante.Notes = entryNote.Text;
        }

        private void OnClickArroser(object sender, EventArgs args)
        {
            //mettre à jour l'enregistrement (les notes)
            plante.dernierArrosage = DateTime.Now;
        }

        async void AfficherInfosPlante(int id)
        {
            //récupérer la plante
            //enregistrer les plantes de la BD dans une liste
            List<Plante> plantes = new List<Plante>();
            plantes.AddRange(await App.Database.GetPlanteAsync());

            plante = new Plante();
            //parcourir les plantes de la liste et les afficher
            foreach (Plante planteA in plantes)
            {
                if (plante.ID_PLANTE == id)
                {
                    plante = planteA;
                }
            }

            //récupérer l'espèce
            //retourner le nom de l'espèce en fonction de son id
            List<Espece> especes = new List<Espece>();
            especes.AddRange(await App.Database.GetEspeceAsync());

            string nomEspece = "";
            //parcourir les plantes de la liste et les afficher
            foreach (Espece espece in especes)
            {
                if (espece.ID_ESPECE == plante.IdEspece)
                {
                    nomEspece = espece.NomEspece.ToString();
                }
            }

            //afficher les informations
            lblNomEspece.Text = plante.ID_PLANTE.ToString() + ", " + nomEspece;
            entryInfo.Text = plante.dernierArrosage.ToString();
            entryNote.Text = plante.Notes.ToString();
        }
    }
}