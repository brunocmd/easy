using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DojoDDD.Business.Interfaces;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteBusiness.ConsultarTodosCliente(); //Todo: chamar a classe de Business
                if (clientes == null)
                    return NoContent();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }

        [HttpGet]
        [Route("{idCliente}")]
        public async Task<IActionResult> GetById([FromRoute] string idCliente)
        {
            try
            {
                var clientes = await _clienteBusiness.ConsultarPorId(idCliente).ConfigureAwait(false); //Todo: chamar a classe de Business
                if (clientes == null)
                    return NoContent();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }
    }
}
