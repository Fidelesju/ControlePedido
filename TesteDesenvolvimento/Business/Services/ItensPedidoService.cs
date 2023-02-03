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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace TesteDesenvolvimento.Business.Services
{
    public class ItensPedidoService : IItensPedidoService
    {
        protected readonly IItensPedidoDb _itensPedidoDB;

        private readonly IItemPedidoRepository _itemPedidoRepository;

        private readonly IItemPedidoCreateMapper _itemPedidoCreateMapper;

        private List<int> _itensIdL;
        public ItensPedidoService(
            IItemPedidoRepository itemPedidoRepository,
            IItemPedidoCreateMapper itemPedidoCreateMapper,
            IItensPedidoDb itensPedidoDb
            )
        {
            _itemPedidoCreateMapper = itemPedidoCreateMapper;
            _itemPedidoRepository = itemPedidoRepository;
            _itensPedidoDB = itensPedidoDb;
        }

        public async Task<int> CreateItensPedido(ItensPedidoCreateRequestModel request)
        {
            ItemPedido itemPedido;
            ItemPedidoCreateValidation validation;
            Dictionary<string, string> errors;
            validation = new ItemPedidoCreateValidation();

            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }

            itemPedido = await _itemPedidoCreateMapper.GetItemPedido(request);
            try
            {
                _itemPedidoRepository.Create(itemPedido);
                return 1;
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }


        //public async Task<List<int>> CreateItemPedidoList(ItemPedidoCreateListRequestModel request)
        //{
        //    ItemPedidoCreateValidation validation;
        //    Dictionary<string, string> errors;
        //    validation = new ItemPedidoCreateValidation();

        //    if (request == null)
        //    {
        //        errors = validation.GetErrors();
        //        throw new CustomValidationException(errors);
        //    }

        //    _itensIdL = new List<int>();
        //    _itensIdL = request.itemId;

        //    try
        //    {
        //        _itemPedidoRepository.Create(_itensIdL);
        //        return _itensIdL;
        //    }
        //    catch (DbUpdateException exception)
        //    {
        //        errors = validation.GetPersistenceErrors(exception);
        //        throw new CustomValidationException(errors);
        //    }
        //}

        public async Task<ItemPedido> GetItemByNome(string nome)
        {
            ItemPedido itemPedido;
            itemPedido = await _itensPedidoDB.GetItemByNome(nome);
            if (itemPedido == null)
            {
                throw new RecordNotFoundException();
            }
            return itemPedido;
        }

        public async Task<ItemPedido> GetItemById(int itemId)
        {
            ItemPedido itemPedido;
            itemPedido = await _itensPedidoDB.GetItemById(itemId);
            if (itemPedido == null)
            {
                Console.WriteLine("chegou aqui ");
                throw new RecordNotFoundException();
            }
            return itemPedido;
        }

        public async Task<bool> Delete(int itemId)
        {
            Dictionary<string, string> errors;
            ItemPedidoDeleteValidation validation;
            validation = new ItemPedidoDeleteValidation();
            bool success;
            try
            {
                success = await _itemPedidoRepository.Delete(itemId);
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
