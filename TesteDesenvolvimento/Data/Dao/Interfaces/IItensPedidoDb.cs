using TesteDesenvolvimento.Data.Models;

namespace TesteDesenvolvimento.Data.Dao.Interfaces
{
    public interface IItensPedidoDb
    {
        Task<ItemPedido> GetItemById(int itemId);
        Task<ItemPedido> GetItemByNome(string nome);
    }
}
