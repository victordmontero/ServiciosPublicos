using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioHistorialCrediticio : Repositorio, IRepositorioSL<HistorialCrediticio>
    {
        public HistorialCrediticio Obtener<K>(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistorialCrediticio> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
