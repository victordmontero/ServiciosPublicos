using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public interface IRepositorioSE<T> where T : class
    {
        void Agregar(T entidad);
    }
}
