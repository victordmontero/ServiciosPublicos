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
    public class RepositorioLog : Repositorio, IRepositorioSE<Log>, IRepositorioSL<Log>
    {

        public Log Obtener<K>(K key)
        {
            Log resultado = null;
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                conn.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerLogs", conn))
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
                if (conn != null)
                    conn.Close();
            }

        }

        public IEnumerable<Log> ObtenerTodos()
        {
            List<Log> resultado = new List<Log>();
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                conn.BeginTransaction();
                using (cmd = new NpgsqlCommand("ObtenerLogs", conn))
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
                if (conn != null)
                    conn.Close();
            }
        }

        public void Agregar(Log entidad)
        {
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                //connection.BeginTransaction();
                //using (cmd = new NpgsqlCommand("INSERT INTO Log (Date,Thread,Level,Logger,Message,Exception,IP)VALUES(:DateParam,:ThreadParam,:LevelParam,:LoggerParam,:MessageParam,:ExceptionParam,:IPParam)", conn))
                //using (cmd = new NpgsqlCommand("AgregarLog(:DateParam,:ThreadParam,:LevelParam,:LoggerParam,:MessageParam,:ExceptionParam,:IPParam)", conn))
                using (cmd = new NpgsqlCommand("AgregarLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(":DateParam", entidad.Date);
                    cmd.Parameters.AddWithValue(":ThreadParam", entidad.Thread);
                    cmd.Parameters.AddWithValue(":LevelParam", entidad.Level);
                    cmd.Parameters.AddWithValue(":LoggerParam", entidad.Logger);
                    cmd.Parameters.AddWithValue(":MessageParam", entidad.Message);
                    cmd.Parameters.AddWithValue(":ExceptionParam", entidad.Exception);
                    cmd.Parameters.AddWithValue(":IPParam", entidad.IP);

                    int result = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }


        public void Actualizar(Log entidad)
        {
            throw new NotImplementedException();
        }
    }
}
