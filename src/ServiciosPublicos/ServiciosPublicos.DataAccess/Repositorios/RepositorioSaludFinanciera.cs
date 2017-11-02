using Npgsql;
using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioSaludFinanciera : Repositorio, IRepositorioSL<SaludFinanciera>
    {

        public SaludFinanciera Obtener<K>(K key)
        {
            NpgsqlCommand cmd = null;
            SaludFinanciera resultado = null;
            try
            {
                connection.Open();
                connection.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerSaludFinanciera", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("cedulaParam", key);
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        resultado = new SaludFinanciera()
                        {
                            Cedula = reader["Cedula"].ToString(),
                            Comentario = reader["Comentario"].ToString(),
                            Indicador = Convert.ToBoolean(reader["Indicador"]),
                            Monto = Convert.ToDouble(reader["Monto"])
                        };
                    }
                }
                return resultado;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public IEnumerable<SaludFinanciera> ObtenerTodos()
        {
            NpgsqlCommand cmd = null;
            List<SaludFinanciera> resultado = new List<SaludFinanciera>();
            try
            {
                connection.Open();
                connection.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerSaludFinanciera", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("cedulaParam", null);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add(new SaludFinanciera()
                            {
                                Cedula = reader["Cedula"].ToString(),
                                Comentario = reader["Comentario"].ToString(),
                                Indicador = Convert.ToBoolean(reader["Indicador"]),
                                Monto = Convert.ToDouble(reader["Monto"])
                            });
                        }
                    }
                }
                return resultado;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
