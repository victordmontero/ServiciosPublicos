using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public abstract class Repositorio : IDisposable
    {
        protected OdbcConnection connection;

        public Repositorio()
        {
            connection = new OdbcConnection("DSN=PostgreSQL35W");
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
