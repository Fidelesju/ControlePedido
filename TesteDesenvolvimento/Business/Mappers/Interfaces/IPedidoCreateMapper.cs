using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Mappers.Interfaces
{
    public interface IPedidoCreateMapper
    {
        Task<Pedido> GetPedido(PedidoCreateRequestModel pedidoCreateRequestModel);

    }
}
