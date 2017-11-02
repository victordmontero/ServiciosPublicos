using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    interface IRepositorioSL<T> where T:class
    {
        T Obtener<K>(K key);
        IEnumerable<T> ObtenerTodos();
    }
}
