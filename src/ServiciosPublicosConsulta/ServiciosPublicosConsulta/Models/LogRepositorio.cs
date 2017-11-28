using Npgsql;
using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ServiciosPublicosConsulta.Models
{
    public class LogRepositorio
    {
        NpgsqlConnection conn;
        public LogRepositorio()
        {
            conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ServiciosPublicos"].ConnectionString);
        }

        public IEnumerable<Log> Obtener(string sql)
        {
            List<Log> resultado = new List<Log>();
            try
            {
                conn.Open();
                conn.BeginTransaction();

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado.Add(new Log()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            IP = reader["IP"].ToString(),
                            Thread = reader["Thread"].ToString(),
                            Level = reader["Level"].ToString(),
                            Logger = reader["Logger"].ToString(),
                            Message = reader["Message"].ToString(),
                            Exception = reader["Exception"].ToString()
                        });
                    }
                    reader.Dispose();
                }
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        private IEnumerable<Log> ObtenerProc(string sql)
        {
            List<Log> resultado = new List<Log>();
            try
            {
                conn.Open();
                conn.BeginTransaction();

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado.Add(new Log()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            IP = reader["IP"].ToString(),
                            Thread = reader["Thread"].ToString(),
                            Level = reader["Level"].ToString(),
                            Logger = reader["Logger"].ToString(),
                            Message = reader["Message"].ToString(),
                            Exception = reader["Exception"].ToString()
                        });
                    }
                    reader.Dispose();
                }
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public IEnumerable<Log> ObtenerLogs()
        {
            string sql = "ObtenerLogs";
            return ObtenerProc(sql);
        }

        //public IEnumerable<Log> ObtenerLogs(string IP)
        //{
            //TODO procedure que obtenga por criterios
        //}
    }
}