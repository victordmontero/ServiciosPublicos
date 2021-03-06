﻿using Npgsql;
using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.DataAccess.Repositorios
{
    public class RepositorioTasaCambiaria : Repositorio, IRepositorioSL<TasaCambiaria>
    {

        public TasaCambiaria Obtener<K>(K key)
        {
            TasaCambiaria resultado = null;
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                conn.BeginTransaction();

                using (cmd = new NpgsqlCommand("ObtenerTasaCambiaria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("codmonedaParam", key);
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            resultado = new TasaCambiaria()
                            {
                                CodMoneda = reader["CodMoneda"].ToString(),
                                Monto = Convert.ToDouble(reader["Monto"])
                            };
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

        public IEnumerable<TasaCambiaria> ObtenerTodos()
        {
            List<TasaCambiaria> resultado = new List<TasaCambiaria>();
            NpgsqlCommand cmd = null;
            try
            {
                conn.Open();
                conn.BeginTransaction();

                using (cmd = new NpgsqlCommand("ObtenerTasaCambiaria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("codmonedaParam", null);
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            resultado.Add(new TasaCambiaria()
                            {
                                CodMoneda = reader["CodMoneda"].ToString(),
                                Monto = Convert.ToDouble(reader["Monto"])
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
