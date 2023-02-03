using Microsoft.AspNetCore.Mvc;
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
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;

        private readonly IPedidoService _pedidoService;

        public PedidoController(
            ILogger<PedidoController> logger,
            IPedidoService pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Criando pedidos 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<int>>> CreatePedido(PedidoCreateRequestModel request)
        {
            BaseResponse<int> response;

            int id;

            try
            {
                id = await _pedidoService.CreatePedido(request);

                if (id == 0)
                {
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao criar um novo pedido, coloque um valor valido")
                        .SetData(0)
                        ;
                    return BadRequest(response);
                }
                if (request.ItemId == 0)
                {
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao criar um novo pedido, informe um item")
                        .SetData(0)
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<int>
                    .Builder()
                    .SetMessage("Pedido criado com sucesso")
                    .SetData(0)
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Buscar pedidos por item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("ItemId/{itemId}")]
        public async Task<ActionResult<BaseResponse<Pedido>>> GetPedidoByItemId(int itemId)
        {
            BaseResponse<ItemPedido> response;
            Pedido pedido;

            try
            {
                pedido = await _pedidoService.GetPedidoByItemId(itemId);

                if (pedido == null)
                {
                    response = BaseResponse<ItemPedido>
                        .Builder()
                        .SetMessage("Falha ao encontrar pedidos cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<ItemPedido>
                    .Builder()
                    .SetMessage("Pedido encotrado com sucesso")
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);

            }
        }

        /// <summary>
        /// Buscando pedidos por id
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("PedidoId/{pedidoId}")]
        public async Task<ActionResult<BaseResponse<Pedido>>> GetPedidoById(int pedidoId)
        {
            BaseResponse<ItemPedido> response;
            Pedido pedido;

            try
            {
                pedido = await _pedidoService.GetPedidoById(pedidoId);

                if (pedido == null)
                {
                    response = BaseResponse<ItemPedido>
                        .Builder()
                        .SetMessage("Falha ao encontrar pedido cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<ItemPedido>
                    .Builder()
                    .SetMessage("Pedido encotrado com sucesso")
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
        /// Buscando pedidos por data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet("Data/{data}")]
        public async Task<ActionResult<BaseResponse<Pedido>>> GetPedidoByData(DateTime data)
        {
            BaseResponse<ItemPedido> response;
            Pedido pedido;

            try
            {
                pedido = await _pedidoService.GetPedidoByData(data);

                if (pedido == null)
                {
                    response = BaseResponse<ItemPedido>
                        .Builder()
                        .SetMessage("Falha ao encontrar pedido cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<ItemPedido>
                    .Builder()
                    .SetMessage("Pedido encotrado com sucesso")
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
        /// Delete pedido
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpPost("Delete/{pedidoId}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(int pedidoId)
        {
            BaseResponse<bool> response;
            bool success;
            try
            {
                success = await _pedidoService.Delete(pedidoId);

                if (success)
                {
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Pedido deletado com sucesso.")
                        .SetData(true)
                    ;
                    return Ok(response);
                }
                response = BaseResponse<bool>
                    .Builder()
                    .SetMessage("Esse pedido não existe.")
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