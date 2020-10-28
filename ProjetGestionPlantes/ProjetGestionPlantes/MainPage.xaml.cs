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

        private void OnClick(object sender, EventArgs args)
        {
            //test
            Button button = (Button)sender;
            button.Text = "réussi";
            btnAddPlante.BackgroundColor = Color.Blue;

            // créer l'étiquette de la nouvelle plante (bouton qui mènera sur sa page) => à metttre dans OnAppearing() avec un foreach pour afficher chaque plante

            // couleur random pour l'étiquette de la plante
            int[,] rgbCouleurs = new int[5, 3] { { 205, 241, 206 }, { 174, 245, 176 }, { 185, 220, 186 }, { 136, 203, 138 }, { 171, 233, 130 } };
            Random rnd = new Random();
            int random = rnd.Next(0, (rgbCouleurs.Length / 3) - 1);

            //version bouton (on ne peut rien mettre dedans)
            //Button btnPlante = new Button();
            //btnPlante.BackgroundColor = Color.FromRgb(rgbCouleurs[random, 0], rgbCouleurs[random, 1], rgbCouleurs[random, 2]);
            //// !!!!! Ajouter le nom et l'espece dans button
            //btnPlante.WidthRequest = 300;
            //btnPlante.HeightRequest = 100;
            //btnPlante.CornerRadius = 20;
            //btnPlante.Margin = 5;
            //btnPlante.Clicked += VoirPlante;

            //version stacklayout----------------------------------------------------------------
            //créer le bouton (à mettre dans le stacklayout)
            Button btnPlante = new Button();
            btnPlante.Clicked += VoirPlante;
            btnPlante.WidthRequest = 50;
            btnPlante.HeightRequest = 50;
            btnPlante.Text = "+";

            //créer le texte (à mettre dans le stacklayout)
            Label nomPlante = new Label();
            nomPlante.Text = "Lili";

            Label especePlante = new Label();
            nomPlante.Text = "Cactus";

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

            //VRAIE FONCTION DE CE BOUTON-----------------------------------------------------------------------------------------------------------------------------------------
            //async voidOnclick
            ////aller sur la page pour ajouter une plante
            //await Navigation.PushAsync(new PageAjouterPlante
            //{
            //});
        }

        private void VoirPlante(object sender, EventArgs args)
        {
            //récupérer l'identifiant de la plante sur laquelle on a appuyé
            //aller sur la page de détails de cette plante (récupérer ses informations grâce à son id)
        }

        private void CallCamera(object sender, EventArgs args)
        {
            //récupérer l'identifiant de la plante sur laquelle on a appuyé
            //aller sur la camera
        }

        //quand la page principale apparaît
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //parcourir les données et afficher toutes les plantes enregistrées en ajouter dynamiquement leurs boutons
        }        
    }
}
