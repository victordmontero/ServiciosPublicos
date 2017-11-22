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
    public class RepositorioIndiceInflacion : Repositorio, IRepositorioSL<IndiceInflacion>
    {

        public IndiceInflacion Obtener<K>(K key)
        {
            IndiceInflacion resultado = null;
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                conn.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerIndiceInflacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("periodoParam", key);
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        resultado = new IndiceInflacion()
                        {
                            Periodo = reader["periodo"].ToString(),
                            Indice = Convert.ToDouble(reader["indice"])
                        };
                    }
                }
                return resultado;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public IEnumerable<IndiceInflacion> ObtenerTodos()
        {
            List<IndiceInflacion> resultado = new List<IndiceInflacion>();
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                conn.BeginTransaction();

                using (cmd = new NpgsqlCommand("ObtenerIndiceInflacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("periodoParam", null);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add(new IndiceInflacion()
                            {
                                Periodo = reader["periodo"].ToString(),
                                Indice = Convert.ToDouble(reader["indice"])
                            });
                        }
                    }
                }
                return resultado;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
    }
}
