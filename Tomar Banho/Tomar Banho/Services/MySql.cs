using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
using Android.App;
using Android.Widget;
using MySqlConnector;

namespace Tomar_Banho.Services
{
    public static class MySql
    {
        public static MySqlConnection ConectarBD()
        {
            MySqlConnection con = new MySqlConnection("server=mysql.freehostia.com;user id=rodmir76_eletrodnei;database=rodmir76_eletrodnei;" +
                "pwd=F_58DkiaytjiZhG;persistsecurityinfo=True");
            con.Open();
            Toast.MakeText(Application.Context, "Banco de dados conectado", ToastLength.Short).Show();
            return con;
        }

        public static TimeSpan BuscarDados()
        {
            var mysqlquery = "SELECT * from TempoChuveiro order BY id DESC";
            using (MySqlDataAdapter da = new MySqlDataAdapter(mysqlquery, ConectarBD()))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    TimeSpan ret = (TimeSpan)dt.Rows[0].ItemArray[2];
                    return ret;
                }

            }

        }

        public static bool VerificaStatus()
        {
            bool status = false;
            var mysqlquery = "SELECT * from TempoChuveiro";
            using (MySqlDataAdapter da = new MySqlDataAdapter(mysqlquery, ConectarBD()))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    status = (bool)dt.Rows[0].ItemArray[3];
                    return status;
                }
            }

        }

        public static void SetaStatus(bool valor)
        {
            var mysqlquery = "UPDATE TempoChuveiro SET status = " + valor + " WHERE ID=1";
            using (MySqlCommand co = new MySqlCommand(mysqlquery, ConectarBD()))
            {
                co.ExecuteNonQuery();
            }

        }
    }
}
