using System.ComponentModel;
using Tomar_Banho.ViewModels;
using Xamarin.Forms;

namespace Tomar_Banho.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}