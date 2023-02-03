using System.Data.Common;
using System.Data.SqlClient;
using TesteDesenvolvimento.Data.Dao.Interfaces;
using TesteDesenvolvimento.Data.Models;

namespace TesteDesenvolvimento.Data.Dao
{
    public class ClienteDb : Db<Cliente>, IDisposable, IClienteDb
    {
        private SqlConnection connection;
        string _stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=devproject_db;Integrated Security=True";

        public ClienteDb()
        {
            this.connection = new SqlConnection(_stringConnection);
            this.connection.Open();
        }
        public void Dispose()
        {
            this.connection.Close();
        }

        /// <summary>
        /// Buscar cliente por id
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<Cliente> GetClienteById(int clienteId)
        {
            Cliente clienteResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = $"select " +
                                        "c.ClienteId as ClienteId," +
                                        "c.PedidoId as PedidoId," +
                                        "c.Email as ValorUnitario," +
                                        "c.Nome as Nome" +
                                        "from cliente c where" +
                                        "c.ClienteId = @clienteId;"
                                        ;

                var pClienteId = new SqlParameter("clienteId", clienteId);
                sql.Parameters.Add(pClienteId);
                clienteResponseModel = await GetQueryResultObject();
                return clienteResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Buscar cliente por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<Cliente> GetClienteByNome(string nome)
        {
            Cliente clienteResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = "$select " +
                                        "c.ClienteId as ClienteId," +
                                        "c.PedidoId as PedidoId," +
                                        "c.Email as ValorUnitario," +
                                        "c.Nome as Nome" +
                                        "from cliente c where" +
                                        "c.Nome = @nome;"
                                        ;

                var pClienteId = new SqlParameter("nome", nome);
                sql.Parameters.Add(pClienteId);
                clienteResponseModel = await GetQueryResultObject();
                return clienteResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Buscar cliente por pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        public async Task<Cliente> GetClienteByPedidoId(int pedidoId)
        {
            Cliente clienteResponseModel;

            try
            {
                var sql = connection.CreateCommand();
                sql.CommandText = "$select " +
                                        $"select " +
                                        "c.ClienteId as ClienteId," +
                                        "c.Nome as Nome," +
                                        "c.PedidoId as ValorUnitario," +
                                        "c.Email as Email" +
                                        "from cliente c where" +
                                        "c.PedidoId = @pedidoId;"
                                        ;

                var pClienteId = new SqlParameter("pedidoId", pedidoId);
                sql.Parameters.Add(pClienteId);
                clienteResponseModel = await GetQueryResultObject();
                return clienteResponseModel;
            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Mapper Cliente
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override Cliente Mapper(DbDataReader reader)
        {
            Cliente cliente;
            cliente = new Cliente();
            cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
            cliente.PedidoId = Convert.ToInt32(reader["PedidoId"]);
            cliente.Nome = Convert.ToString(reader["Nome"]);
            cliente.Email = Convert.ToString(reader["Email"]);
            return cliente;
        }
    }
}
