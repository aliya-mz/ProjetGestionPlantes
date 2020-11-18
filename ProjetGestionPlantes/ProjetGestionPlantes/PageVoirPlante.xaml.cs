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
        static Plante plante = new Plante();
        static Espece espece = new Espece();

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

        private void OnClickReturn(object sender, EventArgs args)
        {
            //retourner sur la page d'accueil
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

        async void AfficherInfosPlante(int plante)
        {
            //Afficher les infos de la plante, enregistrée dans la BD, à partir de son id
        }
    }
}