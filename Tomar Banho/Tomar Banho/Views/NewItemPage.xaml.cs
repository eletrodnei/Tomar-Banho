using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tomar_Banho.Models;
using Tomar_Banho.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tomar_Banho.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}