using System;
using System.Collections.Generic;
using System.Text;

namespace Tomar_Banho.Models
{
    interface IStatusBanco
    {
        void AtivarBanho();
        bool StatusBanho();
        void SetarTempo(TimeSpan tmp);
    }
}
