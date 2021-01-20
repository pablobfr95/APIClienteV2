using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICliente.Aplicação.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICliente.Serviços.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IAppEnderecoServico _appEnderecoServico;

        public EnderecoController(IAppEnderecoServico appEnderecoServico)
        {
            _appEnderecoServico = appEnderecoServico;
        }

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var endereco = _appEnderecoServico.BuscarPorId(id);
                if (endereco == null) return NotFound("Endereço não encontrado !");
                return new JsonResult(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
