using Npgsql;
using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioHistorialCrediticio : Repositorio, IRepositorioSL<HistorialCrediticio>, IRepositorioSE<HistorialCrediticio>
    {
        public HistorialCrediticio Obtener<K>(K key)
        {
            NpgsqlCommand cmd = null;
            try
            {
                connection.Open();
                connection.BeginTransaction();
                cmd = new NpgsqlCommand("ObtenerHistorialCrediticio", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedulaParam", key);
                var reader = cmd.ExecuteReader();
                reader.Read();
                var hc = new HistorialCrediticio()
                {
                    Cedula = reader["Cedula"].ToString(),
                    DeudaRNC = reader["DeudaRNC"].ToString(),
                    Concepto = reader["Concepto"].ToString(),
                    Fecha = (DateTime)reader["Fecha"],
                    Monto = Convert.ToDouble(reader["Monto"])
                    //Cedula = reader[0].ToString(),
                    //DeudaRNC = reader[1].ToString(),
                    //Concepto = reader[2].ToString(),
                    //Fecha = (DateTime)reader[3],
                    //Monto = Convert.ToDouble(reader[4])
                };
                return hc;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public IEnumerable<HistorialCrediticio> ObtenerTodos()
        {
            List<HistorialCrediticio> resultados = new List<HistorialCrediticio>();
            NpgsqlCommand cmd = null;
            try
            {
                connection.Open();
                connection.BeginTransaction();
                cmd = new NpgsqlCommand("ObtenerHistorialCrediticio", connection);
                cmd.Parameters.AddWithValue("cedulaParam", null);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var hc = new HistorialCrediticio()
                        {
                            Cedula = reader["Cedula"].ToString(),
                            DeudaRNC = reader["DeudaRNC"].ToString(),
                            Concepto = reader["Concepto"].ToString(),
                            Fecha = (DateTime)reader["Fecha"],
                            Monto = Convert.ToDouble(reader["Monto"])
                        };
                    resultados.Add(hc);
                }
                return resultados;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public void Agregar(HistorialCrediticio entidad)
        {
            throw new NotImplementedException();
        }
    }
}
