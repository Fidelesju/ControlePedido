using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Services.Interfaces
{
    public interface IItensPedidoService
    {
        Task<int> CreateItensPedido(ItensPedidoCreateRequestModel request);
        //Task<List<int>> CreateItemPedidoList(ItemPedidoCreateListRequestModel request);
        Task<ItemPedido> GetItemByNome(string nome);
        Task<ItemPedido> GetItemById(int itemId);
        Task<bool> Delete(int itemId);


    }
}
