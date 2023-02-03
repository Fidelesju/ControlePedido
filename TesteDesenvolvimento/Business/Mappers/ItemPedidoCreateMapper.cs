using TesteDesenvolvimento.Business.Mappers.Interfaces;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Mappers
{
    public class ItemPedidoCreateMapper : Mapper<ItensPedidoCreateRequestModel>, IItemPedidoCreateMapper
    {
        private readonly ItemPedido _itemPedido;

        public ItemPedidoCreateMapper()
        {
            _itemPedido = new ItemPedido();
        }

        public async Task<ItemPedido> GetItemPedido (ItensPedidoCreateRequestModel itensPedidoCreateRequestModel)
        {
            _itemPedido.Nome = itensPedidoCreateRequestModel.Nome;
            _itemPedido.ValorUnitario = itensPedidoCreateRequestModel.ValorUnitario;

            return _itemPedido;
        }
    }
}
