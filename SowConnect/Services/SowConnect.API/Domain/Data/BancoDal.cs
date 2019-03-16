using SowConnect.API.Config;
using SowConnect.API.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SowConnect.API.Domain.Data
{
    public class BancoDal
    {
        private readonly ConnectionStringConfig _connectionStringConfig;
        private const string TB_NAME = "Banco";
        private const string COL_Id = "Id";
        private const string COL_NomeInstituicao = "NomeInstituicao";
        private const string COL_CodigoInstituicao = "CodigoInstituicao";

        public BancoDal(ConnectionStringConfig connectionStringConfig)
        {
            this._connectionStringConfig = connectionStringConfig;
        }

        public void InserirBanco(Banco banco)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"INSERT INTO {TB_NAME}
                                    (
                                        {COL_NomeInstituicao},
                                        {COL_CodigoInstituicao}
                                    )
                                    VALUES
                                    (
                                        '{banco.NomeInstituicao}',
                                        '{banco.CodigoInstituicao}'
                                    )";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = System.Data.CommandType.Text;
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

        public List<Banco> ObterBancos()
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_NomeInstituicao},
                                            {COL_CodigoInstituicao}
                                        FROM
                                            {TB_NAME}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();
                    List<Banco> bancos = new List<Banco>();
                    while (dr.Read())
                    {
                        Banco banco = new Banco();
                        banco.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        banco.NomeInstituicao = dr.GetString(dr.GetOrdinal(COL_NomeInstituicao));
                        banco.CodigoInstituicao = dr.GetString(dr.GetOrdinal(COL_CodigoInstituicao));
                        bancos.Add(banco);
                    }
                    return bancos;
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

        public Banco ObterBanco(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"SELECT
                                            {COL_Id},
                                            {COL_NomeInstituicao},
                                            {COL_CodigoInstituicao}
                                        FROM
                                            {TB_NAME}
                                        WHERE
                                            {COL_Id} = {id}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 0;
                    IDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        Banco banco = new Banco();
                        banco.Id = dr.GetInt32(dr.GetOrdinal(COL_Id));
                        banco.NomeInstituicao = dr.GetString(dr.GetOrdinal(COL_NomeInstituicao));
                        banco.CodigoInstituicao = dr.GetString(dr.GetOrdinal(COL_CodigoInstituicao));
                        return banco;
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