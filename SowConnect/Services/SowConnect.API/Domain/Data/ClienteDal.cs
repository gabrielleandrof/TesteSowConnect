using SowConnect.API.Config;
using SowConnect.API.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SowConnect.API.Domain.Data
{
    public class ClienteDal
    {
        private readonly ConnectionStringConfig _connectionStringConfig;
        private const string TB_NAME = "Cliente";
        private const string COL_Id = "Id";
        private const string COL_IdBanco = "IdBanco";
        private const string COL_TipoCliente = "TipoCliente";
        private const string COL_Nome = "Nome";

        public ClienteDal(ConnectionStringConfig connectionStringConfig)
        {
            this._connectionStringConfig = connectionStringConfig;
        }

        public void InserirCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"INSERT INTO {TB_NAME}
                                    (
                                        {COL_IdBanco},
                                        {COL_TipoCliente},
                                        {COL_Nome}
                                    )
                                    VALUES
                                    (
                                        {cliente.IdBanco},
                                        {cliente.TipoCliente},
                                        '{cliente.Nome}'
                                    )";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }
            }
        }

        public List<Cliente> ObterClientes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_IdBanco},
                                            {COL_TipoCliente},
                                            {COL_Nome}
                                        FROM
                                            {TB_NAME}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();
                    List<Cliente> clientes = new List<Cliente>();
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        cliente.IdBanco = dr.GetInt32(dr.GetOrdinal(COL_IdBanco));
                        cliente.TipoCliente = (TipoCliente)(dr.GetInt32(dr.GetOrdinal(COL_TipoCliente)));
                        cliente.Nome = dr.GetString(dr.GetOrdinal(COL_Nome));
                        clientes.Add(cliente);
                    }
                    return clientes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }
            }
        }

        public List<Cliente> ObterClientesPorBanco(int idBanco)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_IdBanco},
                                            {COL_TipoCliente},
                                            {COL_Nome}
                                        FROM
                                            {TB_NAME}
                                        WHERE
                                            {COL_IdBanco} = {idBanco}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();
                    List<Cliente> clientes = new List<Cliente>();
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        cliente.IdBanco = dr.GetInt32(dr.GetOrdinal(COL_IdBanco));
                        cliente.TipoCliente = (TipoCliente)(dr.GetInt32(dr.GetOrdinal(COL_TipoCliente)));
                        cliente.Nome = dr.GetString(dr.GetOrdinal(COL_Nome));
                        clientes.Add(cliente);
                    }
                    return clientes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }
            }
        }

        public Cliente ObterCliente(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_IdBanco},
                                            {COL_TipoCliente},
                                            {COL_Nome}
                                        FROM
                                            {TB_NAME}
                                        WHERE
                                            {COL_Id} = {id}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        cliente.IdBanco = dr.GetInt32(dr.GetOrdinal(COL_IdBanco));
                        cliente.TipoCliente = (TipoCliente)(dr.GetInt32(dr.GetOrdinal(COL_TipoCliente)));
                        cliente.Nome = dr.GetString(dr.GetOrdinal(COL_Nome));
                        return cliente;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }
            }
        }
    }
}