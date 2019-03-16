using SowConnect.API.Config;
using SowConnect.API.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SowConnect.API.Domain.Data
{
    public class ContaBancariaDal
    {
        private readonly ConnectionStringConfig _connectionStringConfig;
        private const string TB_NAME = "ContaBancaria";
        private const string COL_Id = "Id";
        private const string COL_IdBanco = "IdBanco";
        private const string COL_IdCliente = "IdCliente";
        private const string COL_Agencia = "Agencia";
        private const string COL_ContaCorrente = "ContaCorrente";
        private const string COL_Saldo = "Saldo";

        public ContaBancariaDal(ConnectionStringConfig connectionStringConfig)
        {
            this._connectionStringConfig = connectionStringConfig;
        }

        public void CriarContaBancaria(ContaBancaria contaBancaria)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"INSERT INTO {TB_NAME}
                                    (
                                        {COL_IdBanco},
                                        {COL_IdCliente},
                                        {COL_Agencia},
                                        {COL_ContaCorrente},
                                        {COL_Saldo}
                                    )
                                    VALUES
                                    (
                                        {contaBancaria.IdBanco},
                                        {contaBancaria.IdCliente},
                                        '{contaBancaria.Agencia}',
                                        '{contaBancaria.ContaCorrente}',
                                        {contaBancaria.Saldo.ToString().Replace(",", ".")}
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

        public List<ContaBancaria> ObterContasPorCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_IdBanco},
                                            {COL_IdCliente},
                                            {COL_Agencia},
                                            {COL_ContaCorrente},
                                            {COL_Saldo}
                                        FROM
                                            {TB_NAME}
                                        WHERE
                                            {COL_IdCliente} = {idCliente}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();
                    List<ContaBancaria> contas = new List<ContaBancaria>();
                    while (dr.Read())
                    {
                        ContaBancaria contaBancaria = new ContaBancaria();
                        contaBancaria.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        contaBancaria.IdBanco = dr.GetInt32(dr.GetOrdinal(COL_IdBanco));
                        contaBancaria.IdCliente = dr.GetInt32(dr.GetOrdinal(COL_IdCliente));
                        contaBancaria.Agencia = dr.GetString(dr.GetOrdinal(COL_Agencia));
                        contaBancaria.ContaCorrente = dr.GetString(dr.GetOrdinal(COL_ContaCorrente));
                        contaBancaria.Saldo = dr.GetDecimal(dr.GetOrdinal(COL_Saldo));
                        contas.Add(contaBancaria);
                    }
                    return contas;
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

        public ContaBancaria ObterConta(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_IdBanco},
                                            {COL_IdCliente},
                                            {COL_Agencia},
                                            {COL_ContaCorrente},
                                            {COL_Saldo}
                                        FROM
                                            {TB_NAME}
                                        WHERE
                                            { COL_Id} = {id}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        ContaBancaria contaBancaria = new ContaBancaria();
                        contaBancaria.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        contaBancaria.IdBanco = dr.GetInt32(dr.GetOrdinal(COL_IdBanco));
                        contaBancaria.IdCliente = dr.GetInt32(dr.GetOrdinal(COL_IdCliente));
                        contaBancaria.Agencia = dr.GetString(dr.GetOrdinal(COL_Agencia));
                        contaBancaria.ContaCorrente = dr.GetString(dr.GetOrdinal(COL_ContaCorrente));
                        contaBancaria.Saldo = dr.GetDecimal(dr.GetOrdinal(COL_Saldo));
                        return contaBancaria;
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

        public void AtualizarSaldo(int id, decimal saldo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"UPDATE ContaBancaria SET Saldo = {saldo.ToString().Replace(",", ".")} WHERE {COL_Id} = {id}";

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
    }
}