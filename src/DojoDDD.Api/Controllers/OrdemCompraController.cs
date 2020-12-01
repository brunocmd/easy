using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DojoDDD.Business.Interfaces;
using DojoDDD.Model.Models.ViewModels;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("ordemcompra")]
    public class OrdemCompraController : Controller
    {
        private readonly IOrdemCompraBusiness _ordemCompraBusiness;

        public OrdemCompraController(IOrdemCompraBusiness ordemCompraBusiness)
        {
            _ordemCompraBusiness = ordemCompraBusiness;
        }

        [HttpGet]
        [Route("{idOrdemCompra}")]
        public async Task<IActionResult> ConsultarPorId([FromRoute] string idOrdemCompra)
        {
            try
            {
                var result = await _ordemCompraBusiness.ConsultarPorId(idOrdemCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdemCompraViewModel ordemCompra)
        {
            try
            {
                var result = await _ordemCompraBusiness.RegistrarOrdemCompra(ordemCompra.ClienteId, ordemCompra.ProdutoId, ordemCompra.QuantidadeSolicitada);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.ToString() });
            }
        }
    }
}
