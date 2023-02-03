using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Business.Services.Interfaces;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.Dao.Interfaces;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;

        private readonly IClienteService _clienteService;


        public ClienteController(
            ILogger<ClienteController> logger,
            IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        /// <summary>
        /// Criando novos clientes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<int>>> CreateCliente(ClienteCreateRequestModel request)
        {
            BaseResponse<int> response;

            int id;

            try
            {
                id = await _clienteService.CreateCliente(request);

                if (id == 0)
                {
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao criar um novo cliente, coloque um valor valido")
                        .SetData(0)
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<int>
                    .Builder()
                    .SetMessage("Cliente criado com sucesso")
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
        /// Buscar cliente por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("Nome/{nome}")]
        public async Task<ActionResult<BaseResponse<Cliente>>> GetClienteByNome(string nome)
        {
            BaseResponse<Cliente> response;
            Cliente cliente;

            try
            {
                cliente = await _clienteService.GetClienteByNome(nome);

                if (cliente == null)
                {
                    response = BaseResponse<Cliente>
                        .Builder()
                        .SetMessage("Falha ao encontrar clientes cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<Cliente>
                    .Builder()
                    .SetMessage("Cliente encotrado com sucesso")
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);

            }
        }

        /// <summary>
        /// Buscar cliente por pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("Pedido/{pedidoId}")]
        public async Task<ActionResult<BaseResponse<Cliente>>> GetClienteByPedido(int pedidoId)
        {
            BaseResponse<Cliente> response;
            Cliente cliente;

            try
            {
                cliente = await _clienteService.GetClienteByPedido(pedidoId);

                if (cliente == null)
                {
                    response = BaseResponse<Cliente>
                        .Builder()
                        .SetMessage("Falha ao encontrar clientes cadastrados")
                        ;
                    return BadRequest(response);
                }
                response = BaseResponse<Cliente>
                    .Builder()
                    .SetMessage("Cliente encotrado com sucesso")
                    ;
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);

            }
        }

        /// <summary>
        /// Delete cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpPost("Delete/{clienteId}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(int clienteId)
        {
            BaseResponse<bool> response;
            bool success;
            try
            {
                success = await _clienteService.Delete(clienteId);

                if (success)
                {
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Cliente deletado com sucesso.")
                        .SetData(true)
                    ;
                    return Ok(response);
                }
                response = BaseResponse<bool>
                    .Builder()
                    .SetMessage("Essa cliente não existe.")
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