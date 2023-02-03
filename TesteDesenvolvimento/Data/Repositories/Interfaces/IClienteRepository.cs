using TesteDesenvolvimento.Data.Models;

namespace TesteDesenvolvimento.Data.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        void Create(Cliente cliente);

        Task<bool> Delete(int clienteId);

    }
}
