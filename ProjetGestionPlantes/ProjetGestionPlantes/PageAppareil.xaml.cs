using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace ProjetGestionPlantes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAppareil : ContentPage
    {
        static string idPlante;

        public PageAppareil()
        {
            InitializeComponent();
        }

        public void ScanQRCode(Result result)
        {
            if (result.Text != null)
            {
                Assigner(result.Text);
            }
        }

        public string Assigner(string a)
        {
            idPlante = a;
            return idPlante;
        }
    }
}