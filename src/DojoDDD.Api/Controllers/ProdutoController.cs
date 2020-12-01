using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DojoDDD.Business.Interfaces;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutoController(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _produtoBusiness.Consultar();
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
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var clientes = await _produtoBusiness.ConsultarPorId(int.Parse(id)).ConfigureAwait(false);
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
