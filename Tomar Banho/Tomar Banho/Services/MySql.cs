using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Widget;
using MySqlConnector;

namespace Tomar_Banho.Services
{
    class MySql
    {
        public static void ConectarBD()
        {
            MySqlConnection con = new MySqlConnection("server=mysql.freehostia.com;user id=rodmir76_eletrodnei;database=rodmir76_eletrodnei;" +
                "pwd=F_58DkiaytjiZhG;persistsecurityinfo=True");
            con.Open();
            Toast.MakeText(Application.Context, "Banco de dados conectado", ToastLength.Short).Show();

        }
    }
}
