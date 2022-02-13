using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tomar_Banho.Models
{
    class StatusBanco
    {
        int id_status;
        Boolean status;

        public int Id_status { get => id_status; set => id_status = value; }
        public bool Status { get => status; set => status = value; }

        public void AtivarBanho()
        {
            //Services.DataSet1 dataSet1 = new Services.DataSet1();
            DataTable data = new DataTable();
            string name = data.TableName;
        }
        public bool StatusBanho()
        {
            //Services.DataSet1 dataSet1 = new Services.DataSet1();


            return true;


        }

    }
}


