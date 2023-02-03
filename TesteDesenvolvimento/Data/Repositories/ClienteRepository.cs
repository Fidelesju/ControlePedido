using System.Data.SqlClient;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.Repositories.Interfaces;

namespace TesteDesenvolvimento.Data.Repositories
{
    public class ClienteRepository : IClienteRepository, IDisposable
    {

        private SqlConnection connection;
        string _stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=devproject_db;Integrated Security=True";

        public ClienteRepository()
        {
            this.connection = new SqlConnection(_stringConnection);
            this.connection.Open();
        }

        /// <summary>
        /// Criando clientes
        /// </summary>
        /// <param name="cliente"></param>
        /// <exception cref="SystemException"></exception>
        public void Create(Cliente cliente)
        {
            try
            {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "INSERT into cliente (Nome, Email, PedidoId) " +
                                         "VALUES ( @nome,@email,@pedidoId)";

                SqlParameter pPedidoId = new SqlParameter();
                pPedidoId.ParameterName = cliente.PedidoId.ToString();

                SqlParameter pNome = new SqlParameter();
                pNome.ParameterName = cliente.Nome;

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = cliente.Email;

                insertCmd.Parameters.Add(pPedidoId);
                insertCmd.Parameters.Add(pNome);
                insertCmd.Parameters.Add(pEmail);


            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Deletando clientes
        /// </summary>
        /// <param name="clienteId"></param>
        /// <exception cref="SystemException"></exception>
        public async Task<bool> Delete(int clienteId)
        {
            try
            {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "DELETE cliente FROM c.ClienteId = @clienteId";

                var pClienteId = new SqlParameter("clienteId", clienteId);

                insertCmd.Parameters.Add(pClienteId);

            }
            catch (SqlException ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return clienteId != 0 ;
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
