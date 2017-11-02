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
    public class RepositorioLog : Repositorio, IRepositorioSE<Log>, IRepositorioSL<Log>
    {

        public Log Obtener<K>(K key)
        {
            Log resultado = null;
            NpgsqlCommand cmd = null;
            try
            {
                connection.Open();
                connection.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerLogs", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdParam", key);
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        resultado = new Log()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Thread = reader["Thread"].ToString(),
                            Level = reader["Level"].ToString(),
                            Logger = reader["Logger"].ToString(),
                            Message = reader["Message"].ToString(),
                            Exception = reader["Exception"].ToString(),
                            IP = reader["IP"].ToString()
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

        public IEnumerable<Log> ObtenerTodos()
        {
            List<Log> resultado = new List<Log>();
            NpgsqlCommand cmd = null;
            try
            {
                connection.Open();
                connection.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerLogs", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdParam", null);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add(new Log()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Date = Convert.ToDateTime(reader["Date"]),
                                Thread = reader["Thread"].ToString(),
                                Level = reader["Level"].ToString(),
                                Logger = reader["Logger"].ToString(),
                                Message = reader["Message"].ToString(),
                                Exception = reader["Exception"].ToString(),
                                IP = reader["IP"].ToString()
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

        public void Agregar(Log entidad)
        {
            NpgsqlCommand cmd = null;
            try
            {
                connection.Open();
                connection.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerLogs", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdParam", entidad.Id);
                    cmd.Parameters.AddWithValue("DateParam", entidad.Date);
                    cmd.Parameters.AddWithValue("ThreadParam", entidad.Thread);
                    cmd.Parameters.AddWithValue("LevelParam", entidad.Level);
                    cmd.Parameters.AddWithValue("LoggerParam", entidad.Logger);
                    cmd.Parameters.AddWithValue("MessageParam", entidad.Message);
                    cmd.Parameters.AddWithValue("ExceptionParam", entidad.Exception);
                    cmd.Parameters.AddWithValue("IPParam", entidad.IP);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }


        public void Actualizar(Log entidad)
        {
            throw new NotImplementedException();
        }
    }
}
