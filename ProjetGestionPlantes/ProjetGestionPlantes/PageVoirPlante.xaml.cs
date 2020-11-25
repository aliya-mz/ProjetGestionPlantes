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
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //récupérer la plante à partir de l'id
            //plante = App.Database.GetPlanteByIdAsync(idPlante);                 
            
            //Afficher les information            
            AfficherInfosPlante(plante);
        }       

        async void OnClickReturn(object sender, EventArgs e)
        {
            // retourner sur la page d'accueil
            await Navigation.PopAsync(false);
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

        async void AfficherInfosPlante(Plante plante)
        {
            //Afficher les infos de la plante, enregistrée dans la BD, à partir de son id
        }
    }
}