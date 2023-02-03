using System.Data.Common;
using System.Data.SqlClient;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.Dao.Interfaces;
using TesteDesenvolvimento.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TesteDesenvolvimento.Data.Dao
{
    public class ItensPedidoDb : Db<ItemPedido>,  IItensPedidoDb
    {
        private SqlConnection connection;
        string _stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=devproject_db;Integrated Security=True";

        public ItensPedidoDb()
        {
            this.connection = new SqlConnection(_stringConnection);
            this.connection.Open();
        }

        /// <summary>
        /// Busca items por id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<ItemPedido> GetItemById(int itemId)
        {
            ItemPedido itemPedidoResponseModel;
            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = $@"select " +
                                        "ip.ItemId as ItemId," +
                                        "ip.Nome as Nome," +
                                        "ip.ValorUnitario as ValorUnitario" +
                                        "from itensPedido ip where" +
                                        "ip.ItemId = " + itemId + ";"
                                        ;
                itemPedidoResponseModel = await GetQueryResultObject();
                return itemPedidoResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Buscar itens por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<ItemPedido> GetItemByNome(string nome)
        {
            ItemPedido itemPedidoResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = "$select " +
                                        "ip.ItemId as ItemId," +
                                        "ip.Nome as Nome," +
                                        "ip.ValorUnitario as ValorUnitario" +
                                        "from itensPedido ip where" +
                                        "ip.Nome = " + nome + ";";
                                        ;

                itemPedidoResponseModel = await GetQueryResultObject();
                return itemPedidoResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Mapper Item pedido
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override ItemPedido Mapper(DbDataReader reader)
        {
            ItemPedido ItemPedido;
            ItemPedido = new ItemPedido();
            ItemPedido.ItemId = Convert.ToInt32(reader["ItemId"]);
            ItemPedido.Nome = Convert.ToString(reader["Nome"]);
            ItemPedido.ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]);
            return ItemPedido;
        }
    }
}
