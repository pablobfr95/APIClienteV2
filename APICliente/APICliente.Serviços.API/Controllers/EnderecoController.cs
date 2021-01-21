using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICliente.Aplicação.DTO;
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

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                var enderecos = _appEnderecoServico.BuscarTodos();
                if (enderecos.Count() == 1) return NoContent();
                return new JsonResult(enderecos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Criar")]
        public IActionResult Criar([FromBody]EnderecoDTO endereco)
        {
            try
            {
                if (ModelState.IsValid) _appEnderecoServico.Adicionar(endereco);
                else
                {
                    var errors = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(errors);
                }
                return StatusCode(201, "Endereço criado com sucesso !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Editar")]
        public IActionResult Editar([FromBody]EnderecoDTO endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_appEnderecoServico.BuscarPorId(endereco.Id) == null) return NotFound("Endereço não encontrado !");
                    _appEnderecoServico.Atualizar(endereco);
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(errors);
                }
                return Ok("Endereço atualizado !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Excluir")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var endereco = _appEnderecoServico.BuscarPorId(id);
                if (endereco == null) return NotFound("Cliente não encontrado !");
                _appEnderecoServico.Excluir(endereco);
                return Ok("Cliente excluído com sucesso !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
