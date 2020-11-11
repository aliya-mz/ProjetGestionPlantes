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
        async void OnClickAddEspece(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(entryEspece.Text) && !string.IsNullOrWhiteSpace(entryJours.Text) && !string.IsNullOrWhiteSpace(entryEspece.Text))
            {
                //Ajout d'une plante avec les propriétés entrées dans le formulaire
                await App.Database.SaveEspeceAsync(new Espece
                {
                    NomEspece = entryEspece.Text,
                    FrequArrosage = int.Parse(entryJours.Text),
                });

                //vider les champs
                entryEspece.Text = entryJours.Text = entryEspece.Text = string.Empty;

                //retourner sur la page d'ajout de plante
            }
        }
    }
}