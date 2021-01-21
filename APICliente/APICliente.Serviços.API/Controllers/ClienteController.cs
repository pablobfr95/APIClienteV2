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
    public class ClienteController : ControllerBase
    {
        private readonly IAppClienteServico _appClienteServico;
        public ClienteController(IAppClienteServico appClienteServico)
        {
            _appClienteServico = appClienteServico;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                var clientes = _appClienteServico.BuscarTodos();
                if (clientes.Count() == 0) return NoContent();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var cliente = _appClienteServico.BuscarPorId(id);
                if (cliente == null) return NotFound("Cliente não encontrado !");
                return new JsonResult(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Criar")]
        public IActionResult Criar([FromBody]ClienteDTO cliente)
        {
            try
            {
                if (ModelState.IsValid) _appClienteServico.Adicionar(cliente);
                else
                {
                    
                    var errors = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(errors);
                }
                return StatusCode(201, "Cliente criado com sucesso !");
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
                var cliente = _appClienteServico.BuscarPorId(id);
                if (cliente == null) return NotFound("Cliente não encontrado !");
                _appClienteServico.Excluir(cliente);
                return Ok("Cliente excluído com sucesso !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] ClienteDTO cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_appClienteServico.BuscarPorId(cliente.Id) == null) return NotFound("Cliente não encontrado !");
                    _appClienteServico.Atualizar(cliente);
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(errors);
                }
                return Ok("Cliente Atualizado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
