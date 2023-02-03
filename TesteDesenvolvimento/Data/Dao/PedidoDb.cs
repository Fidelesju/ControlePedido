using System.Data.Common;
using System.Data.SqlClient;
using TesteDesenvolvimento.Data.Dao.Interfaces;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.ResponseModels;

namespace TesteDesenvolvimento.Data.Dao
{
    public class PedidoDb : Db<PedidoResponseModel>,IPedidoDb
    {
        private SqlConnection connection;
        string _stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=devproject_db;Integrated Security=True";

        public PedidoDb()
        {
            this.connection = new SqlConnection(_stringConnection);
            this.connection.Open();
        }

        /// <summary>
        /// Buscar pedido por id
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<PedidoResponseModel> GetPedidoById(int pedidoId)
        {
            PedidoResponseModel pedidoResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = $"SELECT " +
                                    "p.PedidoId as PedidoId," +
                                    "p.DataCriacao as DataCricao," +
                                    "p.ItemId as ItemId," +
                                    "sum(ip.ValorUnitario) as ValorTotal," +
                                    "count(ip.ItemId) as QuantidadeItens," +
                                    "ip.Nome as NomeItem" +
                                    "FROM" +
                                    "pedidos p" +
                                    "INNER JOIN itensPedido ip on ip.ItemId = p.ItemId" +
                                    "WHERE p.PedidoId =  "+ pedidoId +";"
                                    ;

                pedidoResponseModel = await GetQueryResultObject();
                return pedidoResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Buscar pedido por item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<PedidoResponseModel> GetPedidoByItemId(int itemId)
        {
            PedidoResponseModel pedidoResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = $"SELECT " +
                                   "p.PedidoId as PedidoId," +
                                   "p.DataCriacao as DataCricao," +
                                   "p.ItemId as ItemId," +
                                   "sum(ip.ValorUnitario) as ValorTotal," +
                                   "count(ip.ItemId) as QuantidadeItens," +
                                   "ip.Nome as NomeItem" +
                                   "FROM" +
                                   "pedidos p" +
                                   "INNER JOIN itensPedido ip on ip.ItemId = p.ItemId" +
                                   "WHERE p.PedidoId = " + @itemId + ";"
                                   ;

                pedidoResponseModel = await GetQueryResultObject();
                return pedidoResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }
        
        /// <summary>
        /// Buscar pedido por data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<PedidoResponseModel> GetPedidoByData(DateTime data)
        {
            PedidoResponseModel pedidoResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = $"SELECT " +
                                    "p.PedidoId as PedidoId," +
                                    "p.DataCriacao as DataCricao," +
                                    "p.ItemId as ItemId," +
                                    "sum(ip.ValorUnitario) as ValorTotal," +
                                    "count(ip.ItemId) as QuantidadeItens," +
                                    "ip.Nome as NomeItem" +
                                    "FROM" +
                                    "pedidos p" +
                                    "INNER JOIN itensPedido ip on ip.ItemId = p.ItemId" +
                                    "WHERE p.PedidoId =  " +data + ";"
                                    ;

                pedidoResponseModel = await GetQueryResultObject();
                return pedidoResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Mapper Pedido
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override PedidoResponseModel Mapper(DbDataReader reader)
        {
            PedidoResponseModel pedido;
            pedido = new PedidoResponseModel();

            pedido.PedidoId = Convert.ToInt32(reader["PedidoId"]);
            pedido.ItemId = Convert.ToInt32(reader["ItemId"]);
            pedido.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
            pedido.ValorUnitario = Convert.ToDecimal(reader["ValorTotal"]);
            pedido.QuantidadeItens = Convert.ToInt32(reader["QuantidadeItens"]);
            pedido.QuantidadeItens = Convert.ToInt32(reader["QuantidadeItens"]);
            return pedido;
        }

    }
}
