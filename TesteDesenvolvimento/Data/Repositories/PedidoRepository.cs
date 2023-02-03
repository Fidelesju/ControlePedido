using System.Data.SqlClient;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TesteDesenvolvimento.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository, IDisposable
    {

        private SqlConnection connection;
        string _stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=devproject_db;Integrated Security=True";

        public PedidoRepository()
        {
            this.connection = new SqlConnection(_stringConnection);
            this.connection.Open();
        }

        /// <summary>
        /// Criando pedidos
        /// </summary>
        /// <param name="cliente"></param>
        /// <exception cref="SystemException"></exception>
        public void Create(Pedido pedido)
        {
            try
            {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "INSERT into pedido (ItemId, DataCriacao ) " +
                                         "VALUES (@itemId,getdate())";

                SqlParameter pItemId = new SqlParameter();
                pItemId.ParameterName = pedido.ItemId.ToString();

                SqlParameter pDataCriacao = new SqlParameter();
                pDataCriacao.ParameterName = pedido.DataCriacao.ToString();

                insertCmd.Parameters.Add(pItemId);
                insertCmd.Parameters.Add(pDataCriacao);

            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }

        }

        /// <summary>
        /// Deletando pedidos
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <exception cref="SystemException"></exception>
        public async Task<bool> Delete(int pedidoId)
        {
            try
            {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "DELETE pedido FROM p.PedidoId = @pedidoId";

                var pClienteId = new SqlParameter("pedidoId", pedidoId);

                insertCmd.Parameters.Add(pedidoId);

            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return pedidoId != 0;
        }
        public void Dispose()
                {
                    this.connection.Close();
                }
            }
}
