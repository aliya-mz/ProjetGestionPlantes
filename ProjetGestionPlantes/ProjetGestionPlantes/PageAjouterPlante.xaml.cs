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
    public partial class PageAjouterPlante : ContentPage
    {
        public PageAjouterPlante()
        {
            InitializeComponent();
        }
        private void OnClickCreate(object sender, EventArgs args)
        {
            //test
            Button button = (Button)sender;
            button.Text = "réussi";
            btnCreatePlante.BackgroundColor = Color.Blue;

        }
    }

}