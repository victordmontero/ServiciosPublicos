using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioLog : Repositorio, IRepositorioSE<Log>,IRepositorioSL<Log>
    {

        public Log Obtener<K>(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public void Agregar(Log entidad)
        {
            throw new NotImplementedException();
        }
    }
}
