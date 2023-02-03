using TesteDesenvolvimento.Data.Models;

namespace TesteDesenvolvimento.Data.Dao.Interfaces
{
    public interface IClienteDb
    {
        Task<Cliente> GetClienteById(int clienteId);

        Task<Cliente> GetClienteByNome(string nome);

        Task<Cliente> GetClienteByPedidoId(int pedidoId);
    }
}
