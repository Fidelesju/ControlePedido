using TesteDesenvolvimento.Business.Mappers.Interfaces;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Mappers
{
    public class PedidoCreateMapper : Mapper<PedidoCreateRequestModel>, IPedidoCreateMapper
    {
        private readonly Pedido _pedido;

        public PedidoCreateMapper()
        {
            _pedido = new Pedido();
        }

        public async Task<Pedido> GetPedido (PedidoCreateRequestModel pedidoCreateRequestModel)
        {
            _pedido.ItemId = pedidoCreateRequestModel.ItemId;

            return _pedido;
        }
    }
}
