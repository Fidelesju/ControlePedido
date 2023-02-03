using TesteDesenvolvimento.Data.Models;

namespace TesteDesenvolvimento.Data.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        void Create(ItemPedido itemPedido);

        //List<int> Create(List<ItemPedido> itemPedidoList);

        Task<bool> Delete(int itemId);

    }
}
