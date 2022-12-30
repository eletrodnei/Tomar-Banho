using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Tomar_Banho.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tomar_Banho.Services;
using Android.Util;
using Java.Util.Logging;

namespace Tomar_Banho.Views
{
    public partial class AboutPage : ContentPage
    {
        CancellationTokenSource _canceltoken;
        Models.StatusBanco status = new Models.StatusBanco();
        //bool _statusdathread;

        public AboutPage()
        {
            InitializeComponent();
            _canceltoken = new CancellationTokenSource();
            btn_cancel.IsEnabled = false;
            //Thread ciclo = new Thread(VerificaStatusThread);
            //ciclo.Start();
        }

        //private void VerificaStatusThread()
        //{
        //    for (int i = 0; i < 10; i = 0)
        //    {
        //        _statusdathread = MySql.VerificaStatus();
        //        Console.WriteLine(_statusdathread);
        //        Thread.Sleep(5000);
        //    }
        //}

        private void btn_iniciar(object sender, EventArgs e)
        {
            _canceltoken = new CancellationTokenSource();
            if (!MySql.VerificaStatus())
            {

                MySql.SetaStatus(true);
                //status.AtivarBanho();
                result.Text = "Chuveiro Ocupado !!!";
                _ = Ativar(status.Tempo, _canceltoken.Token);
                btn_start.IsEnabled = false;
                btn_cancel.IsEnabled = true;
            }
            else
            {
                result.Text = "Chuveiro Ocupado !!!";
            }


        }

        private void btn_cancelar(object sender, EventArgs e)
        {


            _canceltoken.Cancel();
            MySql.SetaStatus(false);
            contador.Text = "000";
            btn_start.IsEnabled = true;
            btn_cancel.IsEnabled = false;
            result.Text = "Definindo o Tempo !!";

            //_ = ativar(_canceltoken.Token);

        }

        private async Task Ativar(TimeSpan time, CancellationToken cancelationtoken = default)
        {
            contador.Text = "000";
            for (int c = 0; c < (int)time.TotalSeconds; c++)
            {
                if (cancelationtoken.IsCancellationRequested)
                {
                    contador.Text = "000";
                    throw new TaskCanceledException();

                }
                await Task.Delay(1000);
                contador.Text = (Convert.ToInt64(contador.Text) + 1).ToString();
            }
            await Task.Delay(1000);
            MySql.SetaStatus(false);
            contador.Text = "000";
            btn_start.IsEnabled = true;
            result.Text = "Definindo o Tempo !!";
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
                TimeSpan tmp = new TimeSpan(0, 15, 0);
                status.SetarTempo(tmp);




            }
            else if ((string)radioButton.Content == "20 Minutos")
            {
                TimeSpan tmp = new TimeSpan(0, 20, 0);
                status.SetarTempo(tmp);

            }
            else if ((string)radioButton.Content == "25 Minutos")
            {
                TimeSpan tmp = new TimeSpan(0, 25, 0);
                status.SetarTempo(tmp);
            }

        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (MySql.VerificaStatus())
            {
                btn_start.IsEnabled = false;
                btn_cancel.IsEnabled = false;
                result.Text = "Chuveiro Ocupado !!!";
            }
            else
            {
                btn_start.IsEnabled = true;
                btn_cancel.IsEnabled = false;
                result.Text = "Defina o Tempo !!!";
            }
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            
            if (btn_cancel.IsEnabled)
            {

                //RegistraLog.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                //RegistraLog.Log("Registro de log de auditoria");


                Console.WriteLine("cheguei antes do set false");
                MySql.SetaStatus(false);
                _canceltoken.Cancel();

                Console.WriteLine("cheguei após set false dentro da chave");


            }
            Console.WriteLine("cheguei após set false fora da chave fechando metodo");
        }
    }
}