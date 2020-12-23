using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace ProjetGestionPlantes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAppareil : ContentPage
    {

        public PageAppareil()
        {
            InitializeComponent();
        }

        public void ScanQRCode(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                DonnerEtatPlante(Convert.ToInt32(result.Text));
            });
        }

        //renvoie l'état (à executer dans la page caméra)
        async void DonnerEtatPlante(int id)
        {
            //Calcul de l'état de la plante - - - - - - - - - - - - - - - - - - - - - - 

            //récupérer la plante à partir de l'id - - - - - 
            //enregistrer les plantes de la BD dans une liste
            List<Plante> plantes = new List<Plante>();
            plantes.AddRange(await App.Database.GetPlanteAsync());

            //récupérer l'identifiant de la plante sur laquelle on a appuyé            

            //trouver la plante correspondant à l'identifiant
            Plante planteSelected = new Plante();
            foreach (Plante plante in plantes)
            {
                if (plante.ID_PLANTE == id)
                {
                    planteSelected = plante;
                }
            }

            //récupérer l'espèce à partir de la plante - - - - - -
            //récupérer l'espèce de la plante (nom de l'espèce en fonction de son id)
            List<Espece> especes = new List<Espece>();
            especes.AddRange(await App.Database.GetEspeceAsync());

            Espece monEspece = new Espece();
            //trouver dans la liste l'espèce dont l'id correspond
            foreach (Espece espece in especes)
            {
                if (espece.ID_ESPECE == planteSelected.IdEspece)
                {
                    monEspece = espece;
                }
            }

            //0 = heureux, 1 = moyen, 2 = triste
            int etat;
            //si on n'a pas encore atteint le moment où la plante doit être arrosée
            if ((planteSelected.dernierArrosage - DateTime.Now).TotalDays <= monEspece.FrequArrosage)
            {
                //la plante est heureuse
                etat = 0;
            }
            //si la plante doit être arrosée aujourd'hui
            else if ((planteSelected.dernierArrosage - DateTime.Now).TotalDays == monEspece.FrequArrosage)
            {
                etat = 1;
            }
            //si on a oublié un arrosage
            else
            {
                etat = 2;
            }

            //Afficher l'état de la plante
            switch (etat)
            {
                case 0:
                    DisplayAlert("Résultat du scan", "Cette plante est : ", "OK");
                    break;
                case 1:
                    DisplayAlert("Résultat du scan", "Cette plante est : ", "OK");
                    break;
                case 2:
                    DisplayAlert("Résultat du scan", "Cette plante est : ", "OK");
                    break;
            }
        }
    }
}