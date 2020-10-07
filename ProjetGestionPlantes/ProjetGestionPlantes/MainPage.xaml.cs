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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //à faire quand la page principale apparaît
            //afficher toutes les plantes enregistrées dans la base
        }

        async void OnClick(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            button.Text = "réussi";
            btnAddPlante.BackgroundColor = Color.Blue;

            //aller sur la page pour ajouter une plante
            await Navigation.PushAsync(new PageAjouterPlante
            {
            });
        }
    }
}
