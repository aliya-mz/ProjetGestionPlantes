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
        int[,] rgbCouleurs = new int[5, 3] { { 205, 241, 206 }, { 174, 245, 176 }, { 185, 220, 186 }, { 136, 203, 138 }, { 171, 233, 130 } };
        Random rnd = new Random();
        string nomPlante = "Lili";
        string especePlante = "Cactus";
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, EventArgs args)
        {
            // à ajouter dans le Onclick de la page "ajout nouvelle plante" 
            int random = rnd.Next(0, (rgbCouleurs.Length/3) - 1);

            
           Button btnSection = new Button();
            btnSection.BackgroundColor = Color.FromRgb(rgbCouleurs[random,0], rgbCouleurs[random,1], rgbCouleurs[random,2]);
           // !!!!! Ajouter le nom et l'espece dans button
            btnSection.WidthRequest = 300;
            btnSection.HeightRequest = 100;
            btnSection.CornerRadius = 20;
            btnSection.Margin = 5;
            // ajout dynamique de boutons dans un stackLayout côté Xamarin
            lytContent.Children.Add(btnSection);
        }

    }
}
