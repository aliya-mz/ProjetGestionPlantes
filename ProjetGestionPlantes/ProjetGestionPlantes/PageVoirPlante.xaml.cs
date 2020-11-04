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
        private void OnClickSaveInfo(object sender, EventArgs args)
        {
            //test
            Button button = (Button)sender;
            button.Text = "réussi";
            btnSaveInfoPlant.BackgroundColor = Color.Blue;

        }
    }
}