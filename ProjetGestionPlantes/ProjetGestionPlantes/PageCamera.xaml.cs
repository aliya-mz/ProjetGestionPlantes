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
    public partial class PageCamera : ContentPage
    {
        static string idPlante;
        public PageCamera()
        {
            InitializeComponent();
        }

        public  string ScanView_OnScanResult()
        {
            if(this.scanner.Result.Text != null)
            {
                idPlante = this.scanner.Result.Text;
            }
            return idPlante;
        }
    }
}