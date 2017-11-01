using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Modelos
{
    public class SaludFinanciera
    {
        public string Cedula { get; set; }
        public bool Indicador { get; set; }
        public string Comentario { get; set; }
        public double Monto { get; set; }
    }
}
