using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.ResponseModels;

namespace TesteDesenvolvimento.Data.Dao.Interfaces
{
    public interface IPedidoDb
    {
        Task<PedidoResponseModel> GetPedidoById(int pedidoId);
        Task<PedidoResponseModel> GetPedidoByItemId(int itemId);
        Task<PedidoResponseModel> GetPedidoByData(DateTime data);
    }
}
