using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public abstract class Repositorio : IDisposable
    {
        protected NpgsqlConnection connection;

        public Repositorio()
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgresql"].ConnectionString);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
