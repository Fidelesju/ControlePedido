using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Mappers.Interfaces
{
    public interface IItemPedidoCreateMapper
    {
        Task<ItemPedido> GetItemPedido(ItensPedidoCreateRequestModel itensPedidoCreateRequestModel);

    }
}
