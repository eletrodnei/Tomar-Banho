using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Tomar_Banho.Views
{
    public partial class AboutPage : ContentPage
    {
        CancellationTokenSource _canceltoken = null;
        Models.StatusBanco status = new Models.StatusBanco();
        public AboutPage()
        {
            InitializeComponent();
        }
        
        private void btn_iniciar(object sender, EventArgs e)
        {
            
            status.AtivarBanho();
            ativar();
            
       

        }
        private async void ativar()
        {
            _canceltoken = new CancellationTokenSource();
            var token = _canceltoken.Token;
            _canceltoken.Cancel();
            contador.Text = "000";

            for (int c = 0; c < 50; c++)

            {
                
                await Task.Delay(1000);
                
                contador.Text = (Convert.ToInt64(contador.Text) + 1).ToString();


            }
            //bool estacorrendo = false;
            //int t = (int)status.Tempo1.TotalMinutes;
            //contador.Text = "000";
            //t = 2;

            //result.Text = "Chuveiro Ocupado !!!";

            //estacorrendo = true;
            //Device.StartTimer(TimeSpan.FromSeconds(60), () =>
            //{
            //    contador.Text = (Convert.ToInt64(contador.Text) + 1).ToString();

            //    if (Convert.ToInt64(contador.Text) == t)
            //    {
            //        contador.Text = "000";
            //        result.Text = "Livre para utilizar";
            //        estacorrendo = false;
            //        return estacorrendo;
            //    }
            //    return estacorrendo;
            //});
            //Services.Contador contar = new Services.Contador();

            //contar.Contagem(contador, result);

        }

        private void ChangeTime(object sender, CheckedChangedEventArgs e)
        {
        RadioButton radioButton = sender as RadioButton;


            result.Text = "Definindo o Tempo !!";            
            if ((string)radioButton.Content == "15 Minutos")
            {
                TimeSpan tmp = new TimeSpan(0,15,0);
                status.SetarTempo(tmp);
            

               
                
            }else if((string)radioButton.Content == "20 Minutos")
            {
                TimeSpan tmp = new TimeSpan(0, 20, 0);
                status.SetarTempo(tmp);
                
            }else if((string)radioButton.Content == "25 Minutos")
            {
                TimeSpan tmp = new TimeSpan(0, 25, 0);
                status.SetarTempo(tmp);
            }
            
        }
    }
}