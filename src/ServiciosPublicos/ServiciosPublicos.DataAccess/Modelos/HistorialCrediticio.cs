using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Modelos
{
    public class HistorialCrediticio
    {
        public string Cedula { get; set; }
        public string DeudaRNC { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
    }
}
