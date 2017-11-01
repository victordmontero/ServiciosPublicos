using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioTasaCambiaria : Repositorio, IRepositorioSL<TasaCambiaria>
    {

        public TasaCambiaria Obtener<K>(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TasaCambiaria> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
