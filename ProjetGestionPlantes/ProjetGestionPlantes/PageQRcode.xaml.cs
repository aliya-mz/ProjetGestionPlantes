﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGestionPlantes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageQRcode : ContentPage
    {
        static string valueQRCode = "Bonjour";
        public PageQRcode()
        {
            InitializeComponent();
            //frmQrCode.BarcodeValue = valueQRCode;
        }
    }
}