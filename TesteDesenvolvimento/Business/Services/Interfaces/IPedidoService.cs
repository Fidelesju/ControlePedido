using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<int> CreatePedido(PedidoCreateRequestModel request);
        Task<Pedido> GetPedidoById(int pedidoId);
        Task<Pedido> GetPedidoByItemId(int itemId);
        Task<Pedido> GetPedidoByData(DateTime data);
        Task<bool> Delete(int pedidoId);

    }
}
