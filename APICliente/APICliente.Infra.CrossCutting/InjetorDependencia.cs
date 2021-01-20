using APICliente.Aplicação.Interface;
using APICliente.Aplicação.Servico;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Dominio.Interfaces.Servicos;
using APICliente.Dominio.Servicos;
using APICliente.Infra.CrossCutting.Adapter.Interface;
using APICliente.Infra.CrossCutting.Adapter.Mappper;
using APICliente.Infra.Data.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.CrossCutting.IoC
{
    public class InjetorDependencia
    {
        public static void Registrar(IServiceCollection services)
        {

            // Servicos Aplicação
            services.AddScoped(typeof(IAppClienteServico), typeof(AppClienteServico));
            services.AddScoped(typeof(IAppEnderecoServico), typeof(AppEnderecoServico));

            //Mapper
            services.AddScoped(typeof(IMapperCliente), typeof(MapperCliente));
            services.AddScoped(typeof(IMapperEndereco), typeof(MapperEndereco));


            // Servicos Dominio
            
            services.AddScoped(typeof(IClienteServico), typeof(ClienteServico));
            services.AddScoped(typeof(IEnderecoServico), typeof(EnderecoServico));

            //Repositorios
            
            services.AddScoped(typeof(IClienteRepositorio), typeof(ClienteRepositorio));
            services.AddScoped(typeof(IEnderecoRepositorio), typeof(EnderecoRepositorio));


        }
    }
}
