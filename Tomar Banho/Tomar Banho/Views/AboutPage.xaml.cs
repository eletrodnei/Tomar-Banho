using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Tomar_Banho.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void btn_iniciar(object sender, EventArgs e)
        {
            Models.StatusBanco status = new Models.StatusBanco();
            status.AtivarBanho();

        }
    }
}