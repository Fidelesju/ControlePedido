using Microsoft.EntityFrameworkCore;
using TesteDesenvolvimento.Business.Exceptions;
using TesteDesenvolvimento.Business.Mappers.Interfaces;
using TesteDesenvolvimento.Business.Services.Interfaces;
using TesteDesenvolvimento.Business.Validations;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Dao.Interfaces;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.Repositories;
using TesteDesenvolvimento.Data.Repositories.Interfaces;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoDb _pedidoDB;

        private readonly IPedidoRepository _pedidoRepository;

        private readonly IPedidoCreateMapper _pedidoCreateMapper;

        public PedidoService(
            IPedidoRepository pedidoRepository,
            IPedidoCreateMapper pedidoCreateMapper,
            IPedidoDb pedidoDb
            )
        {
            _pedidoCreateMapper = pedidoCreateMapper;
            _pedidoRepository = pedidoRepository;
            _pedidoDB = pedidoDb;
        }


        public async Task<int> CreatePedido(PedidoCreateRequestModel request)
        {
            Pedido pedido;
            PedidoCreateValidation validation;
            Dictionary<string, string> errors;
            validation = new PedidoCreateValidation();

            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }

            pedido = await _pedidoCreateMapper.GetPedido(request);
            try
            {
                _pedidoRepository.Create(pedido);
                return 1;
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }

        public async Task<Pedido> GetPedidoByItemId(int itemId)
        {
            Pedido pedido;
            pedido = await _pedidoDB.GetPedidoByItemId(itemId);
            if (pedido == null)
            {
                throw new RecordNotFoundException();
            }
            return pedido;
        }

        public async Task<Pedido> GetPedidoById(int pedidoId)
        {
            Pedido pedido;
            pedido = await _pedidoDB.GetPedidoById(pedidoId);
            if (pedido == null)
            {
                throw new RecordNotFoundException();
            }
            return pedido;
        }

        public async Task<Pedido> GetPedidoByData(DateTime data)
        {
            Pedido pedido;
            pedido = await _pedidoDB.GetPedidoByData(data);
            if (pedido == null)
            {
                throw new RecordNotFoundException();
            }
            return pedido;
        }

        public async Task<bool> Delete(int pedidoId)
        {
            Dictionary<string, string> errors;
            PedidoDeleteValidation validation;
            validation = new PedidoDeleteValidation();
            bool success;
            try
            {
                success = await _pedidoRepository.Delete(pedidoId);
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
