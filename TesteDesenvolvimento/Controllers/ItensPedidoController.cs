using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Business.Exceptions;
using TesteDesenvolvimento.Business.Services;
using TesteDesenvolvimento.Business.Services.Interfaces;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensPedidoController : ControllerBase
    {
        private readonly ILogger<ItensPedidoController> _logger;

        private readonly IItensPedidoService _itensPedidoService;

        public ItensPedidoController(
            ILogger<ItensPedidoController> logger,
            IItensPedidoService itensPedidoService)    
        {
            _logger = logger;
            _itensPedidoService = itensPedidoService;
        }


        /// <summary>
        /// Criando novos itens 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<int>>> CreateItemPedido(ItensPedidoCreateRequestModel request)
        {
            BaseResponse<int> response;

            int id;

            try
            {
                id = await _itensPedidoService.CreateItensPedido(request);

                if (id == 0)
                {
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao criar um novo item pedido, coloque um valor valido")
                        .SetData(0)
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<int>
                    .Builder()
                    .SetMessage("Item pedido criado com sucesso")
                    .SetData(0)
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Create item pedido lista
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost("Create/List")]
        //public async Task<ActionResult<BaseResponse<List<int>>>> CreateItemPedidoList(ItemPedidoCreateListRequestModel request)
        //{
        //    BaseResponse<List<int>> response;
        //    List<int> idsList;
        //    try
        //    {
        //        idsList = await _itensPedidoService.CreateItemPedidoList(request);

        //        response = BaseResponse<List<int>>
        //                .Builder()
        //                .SetMessage("Itens cadastradas com sucesso.")
        //                .SetData(idsList)
        //            ;
        //        return Ok(response);
        //    }

        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception.Message);
        //        return BadRequest(exception);
        //    }
        //}


        /// <summary>
        /// Buscar itens por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("{nome}/Nome")]
        public async Task<ActionResult<BaseResponse<ItemPedido>>> GetItemByNome(string nome)
        {
            BaseResponse<ItemPedido> response;
            ItemPedido itemPedido;

            try
            {
                itemPedido = await _itensPedidoService.GetItemByNome(nome);

                if (itemPedido == null)
                {
                    response = BaseResponse<ItemPedido>
                        .Builder()
                        .SetMessage("Falha ao encontrar itens cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<ItemPedido>
                    .Builder()
                    .SetMessage("Item encotrado com sucesso")
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest(exception);

            }
        }

        /// <summary>
        /// Buscar itens por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{itemId}/Id")]
        public async Task<ActionResult<BaseResponse<ItemPedido>>> GetItemById(int itemId)
        {
            BaseResponse<ItemPedido> response;
            ItemPedido itemPedido;

            try
            {
                itemPedido = await _itensPedidoService.GetItemById(itemId);

                if (itemPedido == null)
                {
                    response = BaseResponse<ItemPedido>
                        .Builder()
                        .SetMessage("Falha ao encontrar itens cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<ItemPedido>
                    .Builder()
                    .SetMessage("Item encotrado com sucesso")
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Delete item pedido
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpPost("Delete/{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(int itemPedidoId)
        {
            BaseResponse<bool> response;
            bool success;
            try
            {
                success = await _itensPedidoService.Delete(itemPedidoId);

                if (success)
                {
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Item deletado com sucesso.")
                        .SetData(true)
                    ;
                    return Ok(response);
                }
                response = BaseResponse<bool>
                    .Builder()
                    .SetMessage("Esse item não existe.")
                    .SetData(false)
                ;
                return BadRequest(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);

            }
        }
    }
}