using SowConnect.API.Config;
using SowConnect.API.Domain.Model;
using System;
using System.Data.SqlClient;

namespace SowConnect.API.Domain.Data
{
    public class MovimentacaoDal
    {
        private readonly ConnectionStringConfig _connectionStringConfig;
        private const string TB_NAME = "Movimentacao";
        private const string COL_Id = "Id";
        private const string COL_TipoMovimentacao = "TipoMovimentacao";
        private const string COL_IdContaOrigem = "IdContaOrigem";
        private const string COL_IdContaDestino = "IdContaDestino";
        private const string COL_Valor = "Valor";
        private const string COL_DataMovimentacao = "DataMovimentacao";

        public MovimentacaoDal(ConnectionStringConfig connectionStringConfig)
        {
            this._connectionStringConfig = connectionStringConfig;
        }

        public void InserirMovimentacao(Movimentacao movimentacao)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringConfig.Default))
            {
                try
                {
                    string query = $@"INSERT INTO {TB_NAME}
                                    (
                                        {COL_TipoMovimentacao},
                                        {COL_IdContaOrigem},
                                        {COL_IdContaDestino},
                                        {COL_Valor},
                                        {COL_DataMovimentacao}
                                    )
                                    VALUES
                                    (
                                        {(int)movimentacao.TipoMovimentacao},
                                        {movimentacao.IdContaOrigem},
                                        {movimentacao.IdContaDestino},
                                        {movimentacao.Valor.ToString().Replace(",", ".")},
                                        GETDATE()
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
    }
}