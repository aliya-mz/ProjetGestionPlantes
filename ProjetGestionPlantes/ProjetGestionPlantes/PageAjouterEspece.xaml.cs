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
    public partial class PageAjouterEspece : ContentPage
    {
        public PageAjouterEspece()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //vider les champs
            entryEspece.Text = string.Empty;
            entryJours.Text = "1";
        }

        async void OnClickAddEspece(object sender, EventArgs args)
        {
            //si tous les champs sont entrés
            if (!string.IsNullOrWhiteSpace(entryEspece.Text) && !string.IsNullOrWhiteSpace(entryJours.Text) && !string.IsNullOrWhiteSpace(entryEspece.Text))
            {
                //Ajout d'une espèce avec les propriétés entrées dans le formulaire
                await App.Database.SaveEspeceAsync(new Espece
                {
                    NomEspece = entryEspece.Text,
                    FrequArrosage = int.Parse(entryJours.Text),
                });

                //retourner sur le formulaire d'ajout de plante
                ((App)App.Current).ChangeScreen(new PageAjouterPlante());
            }            
        }
    }
}