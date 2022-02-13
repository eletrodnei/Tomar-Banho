using System;
using Tomar_Banho.Services;
using Tomar_Banho.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tomar_Banho
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
