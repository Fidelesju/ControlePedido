using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Mappers.Interfaces
{
    public interface IClienteCreateMapper
    {
        Task<Cliente> GetCliente(ClienteCreateRequestModel clienteCreateRequestModel);
    }
}
