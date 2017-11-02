using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Modelos
{
    public class IndiceInflacion
    {
        public int InflacionId { get; set; }
        public string Periodo { get; set; }
        public double Indice { get; set; }
    }
}
