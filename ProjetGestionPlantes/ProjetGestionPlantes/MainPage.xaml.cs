﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGestionPlantes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void OnClick(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            button.Text = "réussi";
            BtnTest.BackgroundColor = Color.Red;
        }
    }
}
