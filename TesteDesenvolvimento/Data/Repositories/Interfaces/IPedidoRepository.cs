using TesteDesenvolvimento.Data.Models;

namespace TesteDesenvolvimento.Data.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void Create(Pedido pedido);

        Task<bool> Delete(int pedidoId);

    }
}
