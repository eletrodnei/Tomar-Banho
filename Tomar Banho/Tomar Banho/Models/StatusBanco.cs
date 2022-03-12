using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tomar_Banho.Views;

namespace Tomar_Banho.Models
{
    class StatusBanco : IStatusBanco
    {
        private int id_status;
        private Boolean status;
        private TimeSpan tempo;

        public StatusBanco()
        {
            this.status = false;
        }

        private int Id_status { get => id_status; set => id_status = value; }
        private bool Status { get => status; set => status = value; }

        

        private TimeSpan Tempo { get => Tempo1; set => Tempo1 = value; }
        public TimeSpan Tempo1 { get => tempo; set => tempo = value; }

        public void SetarTempo(TimeSpan tmp)
        {
            this.Tempo1 = tmp;            
        }
        
        public void AtivarBanho()
        {
            this.status = true;
            
        }
        public bool StatusBanho()
        {
            //Services.DataSet1 dataSet1 = new Services.DataSet1();


            return this.status;


        }

    }
}


