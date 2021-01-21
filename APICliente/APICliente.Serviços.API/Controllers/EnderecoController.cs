using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APICliente.Aplicação.DTO;
using APICliente.Aplicação.Interface;
using APICliente.Serviços.API.SwaggerExemplos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

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

        /// <summary>
        /// Buscar endereço por id
        /// </summary>
        /// <response code="404">Endereço não encontrado !</response>
        [HttpGet("BuscarPorId")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Endereço Encontrado !", typeof(EnderecoDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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


        /// <summary>
        /// Buscar todos os endereços
        /// </summary>
        [HttpGet("Listar")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Endereços encontrados !", typeof(List<EnderecoDTO>))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Não possui nenhum Endereço !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
        public IActionResult Listar()
        {
            try
            {
                var enderecos = _appEnderecoServico.BuscarTodos();
                if (enderecos.Count() == 0) return NoContent();
                return new JsonResult(enderecos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Criar Endereço
        /// </summary>
        /// <response code="400">Dados Inválidos !</response>
        [HttpPost("Criar")]
        [SwaggerRequestExample(typeof(EnderecoDTO), typeof(CriarEnderecoExemploModelSwagger))]
        [SwaggerResponse((int)HttpStatusCode.OK, "Endereço criado com sucesso !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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

        /// <summary>
        /// Editar Endereço
        /// </summary>
        /// <response code="400">Dados Inválidos !</response>
        /// <response code="404">Endereço não encontrado !</response>
        [HttpPut("Editar")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Endereço editado com sucesso !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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

        /// <summary>
        /// Excluir Endereço
        /// </summary>
        /// <response code="404">Endereço não encontrado !</response>
        [HttpDelete("Excluir")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Endereço excluído com sucesso !")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor  !")]
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
