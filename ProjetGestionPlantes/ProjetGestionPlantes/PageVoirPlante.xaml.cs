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
        public PageVoirPlante()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //récupérer le Text du bouton qui a mené sur cette page
            //Plante plante = BindingContext;

            //Afficher les information
            //AfficherInfosPlante(plante);
        }

        async void AfficherInfosPlante(int plante)
        {
            //Afficher les infos de la plante, enregistrée dans la BD, à partir de son id

        }
    }
}