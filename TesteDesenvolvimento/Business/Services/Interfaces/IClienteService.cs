using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Services.Interfaces
{
    public interface IClienteService
    {
        Task<int> CreateCliente(ClienteCreateRequestModel request);
        Task<Cliente> GetClienteByPedido(int pedidoId);
        Task<Cliente> GetClienteByNome(string nome);
        Task<Cliente> GetClienteById(int pedidoId);
        Task<bool> Delete(int clienteId);

    }
}
