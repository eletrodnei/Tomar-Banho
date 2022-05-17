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
        CancellationTokenSource _canceltoken;

        Models.StatusBanco status = new Models.StatusBanco();
        public AboutPage()
        {
            InitializeComponent();
            
        }
        
        private void btn_iniciar(object sender, EventArgs e)
        {
            Services.MySql.ConectarBD();
            _canceltoken = new CancellationTokenSource();
            status.AtivarBanho();

            result.Text = "Chuveiro Ocupado !!!";
            _ = ativar(_canceltoken.Token);
            btn_start.IsEnabled = false;


        }

        private void btn_cancelar(object sender, EventArgs e)
        {
            

            _canceltoken.Cancel();
            btn_start.IsEnabled = true;
            result.Text = "Definindo o Tempo !!";

            //_ = ativar(_canceltoken.Token);

        }

        private async Task ativar(CancellationToken cancelationtoken=default)
        {
            
            
            
            
            contador.Text = "000";
           
                for (int c = 0; c < 5; c++)
                {
                if (cancelationtoken.IsCancellationRequested)
                {
                    contador.Text = "000";
                    throw new TaskCanceledException();
                    
                }
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