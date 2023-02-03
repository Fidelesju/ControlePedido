using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Business.Exceptions;
using TesteDesenvolvimento.Business.Mappers.Interfaces;
using TesteDesenvolvimento.Business.Services.Interfaces;
using TesteDesenvolvimento.Business.Validations;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.Repositories.Interfaces;
using TesteDesenvolvimento.Data.RequestModels;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvimento.Data.Dao.Interfaces;

namespace TesteDesenvolvimento.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteDb _clienteDB;

        private readonly IClienteCreateMapper _clienteCreateMapper;

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(
            IClienteCreateMapper clienteCreateMapper,
            IClienteRepository clienteRepository,
            IClienteDb clienteDb)
        {
            _clienteCreateMapper = clienteCreateMapper;
            _clienteRepository = clienteRepository;
            _clienteDB = clienteDb;
        }

        public async Task<int> CreateCliente(ClienteCreateRequestModel request)
        {
            Cliente cliente;
            ClienteCreateValidation validation;
            Dictionary<string, string> errors;
            validation = new ClienteCreateValidation();

            if(!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }

            cliente = await _clienteCreateMapper.GetCliente(request);
            try
            {
                _clienteRepository.Create(cliente);
                return 1;
            }
            catch(DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }

        public async Task<Cliente> GetClienteByNome(string nome)
        {
            Cliente cliente;
            cliente = await _clienteDB.GetClienteByNome(nome);
            if (cliente == null)
            {
                throw new RecordNotFoundException();
            }
            return cliente;
        }

        public async Task<Cliente> GetClienteByPedido(int pedidoId)
        {
            Cliente cliente;
            cliente = await _clienteDB.GetClienteByPedidoId(pedidoId);
            if (cliente == null)
            {
                throw new RecordNotFoundException();
            }
            return cliente;
        }

        public async Task<Cliente> GetClienteById(int pedidoId)
        {
            Cliente cliente;
            cliente = await _clienteDB.GetClienteById(pedidoId);
            if (cliente == null)
            {
                throw new RecordNotFoundException();
            }
            return cliente;
        }

        public async Task<bool> Delete(int clienteId)
        {
            Dictionary<string, string> errors;
            ClienteDeleteValidation validation;
            validation = new ClienteDeleteValidation();
            bool success;
            try
            {
                success = await _clienteRepository.Delete(clienteId);
                return success;
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }
    }
}
