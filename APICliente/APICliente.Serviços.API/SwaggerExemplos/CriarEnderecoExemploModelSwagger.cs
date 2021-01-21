using APICliente.Aplicação.DTO;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Serviços.API.SwaggerExemplos
{
    public class CriarEnderecoExemploModelSwagger : IExamplesProvider<EnderecoDTO>
    {
        public EnderecoDTO GetExamples()
        {
            return new EnderecoDTO
            {
                Logradouro = "rua sei la das contas",
                Bairro = "em algum bairro",
                Cidade = "em alguma cidade",
                Estado = "em algum estado",
                ClienteId = 1
            };
        }
    }
}
