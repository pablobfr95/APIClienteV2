using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.Data.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        private readonly APIClienteContext _context;

        public ClienteRepositorio(APIClienteContext context) : base(context)
        {
            _context = context;
        }
    }
}
