using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioIndiceInflacion : Repositorio, IRepositorioSL<IndiceInflacion>
    {

        public IndiceInflacion Obtener<K>(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndiceInflacion> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
