using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.Data.Repositorio
{
    public class EnderecoRepositorio : RepositorioBase<Endereço>, IEnderecoRepositorio
    {
        private readonly APIClienteContext _context;
        public EnderecoRepositorio(APIClienteContext context) : base(context)
        {
            _context = context;
        }
    }
}
