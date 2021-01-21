using APICliente.Aplicação.DTO;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Serviços.API.SwaggerExemplos
{
    public class EditarClienteExemploModelSwagger : IExamplesProvider<ClienteDTO>
    {
        public ClienteDTO GetExamples()
        {
            return new ClienteDTO
            {
                Id = 1,
                Nome = "Algum nome",
                Cpf = "314.354.190-30",
                DataNascimento = "01/01/2000"
            };
        }
    }
}
