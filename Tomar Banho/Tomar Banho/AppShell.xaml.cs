using System;
using System.Collections.Generic;
using Tomar_Banho.ViewModels;
using Tomar_Banho.Views;
using Xamarin.Forms;

namespace Tomar_Banho
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
