using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APICliente.Aplicação.DTO;
using APICliente.Aplicação.Interface;
using APICliente.Serviços.API.SwaggerExemplos;
using APICliente.Serviços.API.teste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

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


        /// <summary>
        /// Buscar cliente por Id
        /// </summary>
        /// <response code="404">Cliente não encontrado !</response>
        [HttpGet("BuscarPorId")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Cliente Encontrado !", typeof(ClienteDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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


        /// <summary>
        /// Buscar todos clientes
        /// </summary>
        [HttpGet("Listar")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Clientes encontrados !", typeof(List<ClienteDTO>))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Não possui nenhum Cliente !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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


        /// <summary>
        /// Criar Cliente
        /// </summary>
        /// <response code="400">Dados Inválidos !</response>
        [HttpPost("Criar")]
        [SwaggerRequestExample(typeof(ClienteDTO), typeof(CriarClienteExemploModelSwagger))]
        [SwaggerResponse((int)HttpStatusCode.OK, "Cliente criado com sucesso !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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

        /// <summary>
        /// Editar Cliente
        /// </summary>
        /// <response code="400">Dados Inválidos !</response>
        /// <response code="404">Cliente não encontrado !</response>
        [HttpPut("Editar")]
        [SwaggerRequestExample(typeof(ClienteDTO), typeof(EditarClienteExemploModelSwagger))]
        [SwaggerResponse((int)HttpStatusCode.OK, "Cliente editado com sucesso !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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

        /// <summary>
        /// Excluir Cliente
        /// </summary>
        /// <response code="404">Cliente não encontrado !</response>
        [HttpDelete("Excluir")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Cliente excluído com sucesso !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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

    }
}
