using System;
using System.ComponentModel;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;


namespace Tomar_Banho.Views
{
    public partial class AboutPage : ContentPage
    {
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
        private void ativar()
        {
            int t = (int)status.Tempo1.TotalMinutes;
            contador.Text = "000";
            //t = 2;

            result.Text = "Chuveiro Ocupado !!!";

            bool estacorrendo = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(60000), () =>
            {
                contador.Text = (Convert.ToInt64(contador.Text) + 1).ToString();
                if (Convert.ToInt64(contador.Text) == t)
                {
                    contador.Text = "000";
                    result.Text = "Livre para utilizar";
                    return estacorrendo = false;

                }
                return estacorrendo;
            });
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