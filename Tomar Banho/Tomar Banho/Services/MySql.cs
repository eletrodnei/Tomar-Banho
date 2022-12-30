using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Android.App;
using Android.Widget;
using MySqlConnector;

namespace Tomar_Banho.Services
{
    public static class MySql
    {
        public static MySqlConnection con = new MySqlConnection("server=mysql.freehostia.com;user id=rodmir76_eletrodnei;database=rodmir76_eletrodnei;" +
    "pwd=F_58DkiaytjiZhG;persistsecurityinfo=True");

        public static MySqlConnection ConectarBD()
        {
            //for (int c = 0; c < 6; c++)
            //{
            while (con.State != ConnectionState.Open)
            {
                try
                {
                    //if (con.State != ConnectionState.Open)
                    //{
                    con.Open();
                    //}
                    //Toast.MakeText(Application.Context, "Banco de dados conectado", ToastLength.Short).Show();
                    return con;
                }
                catch (Exception ex)
                {
                    con.Close();
                    Console.WriteLine("Falha ao conectar ao banco de dados !!!");
                    Toast.MakeText(Application.Context, "Falha ao conectar ao banco de dados !!!", ToastLength.Short).Show();
                    //c++;
                }
            }
            //}
            return con;
        }

        //public static TimeSpan BuscarDados()
        //{
        //    var mysqlquery = "SELECT * from TempoChuveiro order BY id DESC";
        //    using (MySqlDataAdapter da = new MySqlDataAdapter(mysqlquery, ConectarBD()))
        //    {
        //        using (DataTable dt = new DataTable())
        //        {
        //            da.Fill(dt);
        //            TimeSpan ret = (TimeSpan)dt.Rows[0].ItemArray[2];
        //            return ret;
        //        }

        //    }

        //}

        public static bool VerificaStatus()
        {
            for (int c = 0; c < 6; c++)
            {
                try
                {
                    bool status;
                    var mysqlquery = "SELECT * from TempoChuveiro";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(mysqlquery, ConectarBD()))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            status = (bool)dt.Rows[0].ItemArray[3];
                            con.Close();
                            return status;
                        }
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    Console.WriteLine("Falha ao Verificar dados no banco de dados !!!");
                    Toast.MakeText(Application.Context, "Falha ao Verificar dados no banco de dados !!!", ToastLength.Short).Show();
                    c++;
                }
            }
            return false;
        }

        public static void SetaStatus(bool valor)
        {
            for (int c = 0; c < 6; c++)
            {
                try
                {
                    var mysqlquery = "UPDATE TempoChuveiro SET status = " + valor + " WHERE ID=1";
                    using (MySqlCommand co = new MySqlCommand(mysqlquery, ConectarBD()))
                    {
                        co.ExecuteNonQuery();
                    }
                    con.Close();
                    Console.WriteLine("setstatus concluido --- ");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("falha ao executar o setstatus");
                    con.Close();
                    c++;
                }
            }
        }
    }
}
