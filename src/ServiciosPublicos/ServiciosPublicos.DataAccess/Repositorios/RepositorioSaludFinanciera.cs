using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioSaludFinanciera : Repositorio, IRepositorioSL<SaludFinanciera>
    {

        public SaludFinanciera Obtener<K>(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaludFinanciera> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
