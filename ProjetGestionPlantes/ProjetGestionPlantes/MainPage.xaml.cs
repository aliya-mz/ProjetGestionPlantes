using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGestionPlantes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //ok
        protected override void OnAppearing()
        {
            //Quand on revient sur la page d'accueil

            base.OnAppearing();
            AfficherPlantes();
        }

        //ok
        private void AjouterPlante_Onclick(object sender, EventArgs e)
        {
            ((App)App.Current).ChangeScreen(new PageAjouterPlante());
        }
        private void CallCamera(object sender, EventArgs e) {           
            ((App)App.Current).ChangeScreen(new PageAppareil());
        }
        //ok
        async void AfficherPlantes()
        {
            //enregistrer les plantes de la BD dans une liste
            List<Plante> plantes = new List<Plante>();
            plantes.AddRange(await App.Database.GetPlanteAsync());

            //couleurs pour les étiquettes des plantes
            int[,] rgbCouleurs = new int[5, 3] { { 205, 241, 206 }, { 174, 245, 176 }, { 185, 220, 186 }, { 136, 203, 138 }, { 171, 233, 130 } };
            Random rnd = new Random();

            //parcourir les plantes de la liste et les afficher
            foreach (Plante plante in plantes)
            {
                // couleur random pour l'étiquette de la plante                
                int random = rnd.Next(0, (rgbCouleurs.Length / 3) - 1);

                //créer le bouton (à mettre dans le stacklayout) - enregistrer l'id de la plante dans le Text
                Button btnPlante = new Button();
                btnPlante.Clicked += VoirPlante;
                btnPlante.WidthRequest = 50;
                btnPlante.HeightRequest = 50;
                btnPlante.Text = plante.ID_PLANTE.ToString();

                //créer le texte (à mettre dans le stacklayout)
                Label nomPlante = new Label();
                nomPlante.Text = plante.Nom;

                Label especePlante = new Label();
                especePlante.Text = plante.IdEspece.ToString(); //remplacer id espece par nomEspece de la table Espece avec une jointure

                StackLayout textPlante = new StackLayout();
                textPlante.Children.Add(nomPlante);
                textPlante.Children.Add(especePlante);

                //créer le stacklayout de la plante
                StackLayout vuePlante = new StackLayout();
                vuePlante.BackgroundColor = Color.FromRgb(rgbCouleurs[random, 0], rgbCouleurs[random, 1], rgbCouleurs[random, 2]);
                btnPlante.WidthRequest = 300;
                btnPlante.HeightRequest = 100;
                //btnPlante.CornerRadius = 20;
                vuePlante.Margin = 5;

                //mettre les éléments créés dans ce stacklayout
                vuePlante.Children.Add(textPlante);
                vuePlante.Children.Add(btnPlante);

                // ajout dynamique de boutons dans un stackLayout côté Xamarin
                lytContent.Children.Add(vuePlante);
            }
        }

        //ok
        async void VoirPlante(object sender, EventArgs e)
        {
            //enregistrer les plantes de la BD dans une liste
            List<Plante> plantes = new List<Plante>();
            plantes.AddRange(await App.Database.GetPlanteAsync());

            //récupérer l'identifiant de la plante sur laquelle on a appuyé
            Button buttonPlante = (Button)sender;
            int idPlante = Convert.ToInt32(buttonPlante.Text);

            //trouver la plante correspondant à l'identifiant
            Plante planteSelected = new Plante();
            foreach (Plante plante in plantes)
            {
                if (plante.ID_PLANTE == idPlante)
                {
                    planteSelected = plante;
                }
            }

            //aller sur la page de détails de cette plante en envoyant en paramètre la plante
            ((App)App.Current).ChangeScreen(new PageVoirPlante(planteSelected));
        }

        //renvoie l'état (à executer dans la page caméra)
        private int DonnerEtatPlante(Plante plante, Espece espece)
        {
            //Calcul de l'état de la plante - - - - - - - - - - - - - - - - - - - - - - 

            //récupérer la plante à partir de l'id
            //récupérer l'espèce à partir de la plante
            //Espece espece = App.Database.GetEspeceByIdAsync(plante.IdEspece);


            //0 = heureux, 1 = moyen, 2 = triste
            int etat;
            //si on n'a pas encore atteint le moment où la plante doit être arrosée
            if ((plante.dernierArrosage - DateTime.Now).TotalDays <= espece.FrequArrosage)
            {
                //la plante est heureuse
                etat = 0;
            }
            //si la plante doit être arrosée aujourd'hui
            else if ((plante.dernierArrosage - DateTime.Now).TotalDays == espece.FrequArrosage)
            {
                etat = 1;
            }
            //si on a oublié un arrosage
            else
            {
                etat = 2;
            }
            return etat;
        }
    }
}