using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.Repositories.Interfaces;
using TesteDesenvolvimento.Data.ResponseModels;

namespace TesteDesenvolvimento.Data.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository, IDisposable
    {

        private SqlConnection connection;
        string _stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=devproject_db;Integrated Security=True";

        public ItemPedidoRepository()
        {
            this.connection = new SqlConnection(_stringConnection);
            this.connection.Open();
        }

        /// <summary>
        /// Criando item pedido
        /// </summary>
        /// <param name="cliente"></param>
        /// <exception cref="SystemException"></exception>
        public void Create(ItemPedido itemPedido)
        {
            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = "INSERT into itemPedido (Nome, ValorUnitario ) " +
                                   "VALUES (@Nome,@ValorUnitario)";

                SqlParameter pNome = new SqlParameter();
                pNome.ParameterName = itemPedido.Nome; ;

                SqlParameter pValorUnitario = new SqlParameter();
                pValorUnitario.ParameterName = itemPedido.ValorUnitario.ToString();

                pValorUnitario.Value = itemPedido.ValorUnitario;

          
                sql.Parameters.Add(pNome);
                sql.Parameters.Add(pValorUnitario);


            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        //public List<int> Create(List<ItemPedido> itemPedidoList)
        //{
        //    List<int> ids;
        //    ids = new List<int>();
        //    foreach (ItemPedido itens in itemPedidoList)
        //    {
        //        if (itens.ItemId > 0)
        //        {
        //            var sql = connection.CreateCommand();
        //            sql.CommandText = "INSERT into itemPedido (Nome, ValorUnitario ) " +
        //                               "VALUES (@Nome,@ValorUnitario)";

        //            SqlParameter pNome = new SqlParameter();
        //            pNome.ParameterName = itemPedidoList.Nome;

        //            SqlParameter pValorUnitario = new SqlParameter();
        //            pValorUnitario.ParameterName = itemPedidoList.ValorUnitario.ToString();

        //            pValorUnitario.Value = itemPedidoList.ValorUnitario;


        //            sql.Parameters.Add(pNome);
        //            sql.Parameters.Add(pValorUnitario);
        //        }
        //    }
        //    return ids;
        //}

        /// <summary>
        /// Deletando item pedido
        /// </summary>
        /// <param name="itemId"></param>
        /// <exception cref="SystemException"></exception>
        public async Task<bool> Delete(int itemId)
        {
            try
            {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "DELETE itemPedido FROM ip.ItemId = @itemId";

                var pClienteId = new SqlParameter("itemId", itemId);

                insertCmd.Parameters.Add(pClienteId);

            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return itemId != 0;
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
