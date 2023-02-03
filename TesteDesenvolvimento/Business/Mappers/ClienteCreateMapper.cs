using TesteDesenvolvimento.Business.Mappers.Interfaces;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Mappers
{
    public class ClienteCreateMapper : Mapper<ClienteCreateRequestModel>, IClienteCreateMapper
    {
        private readonly Cliente _cliente;

        public ClienteCreateMapper()
        {
            _cliente = new Cliente();
        }

        public async Task<Cliente> GetCliente (ClienteCreateRequestModel clienteCreateRequestModel)
        {
            _cliente.Nome = clienteCreateRequestModel.Nome;
            _cliente.Email = clienteCreateRequestModel.Email;
            _cliente.PedidoId = clienteCreateRequestModel.PedidoId;

            return _cliente;
        }
    }
}
