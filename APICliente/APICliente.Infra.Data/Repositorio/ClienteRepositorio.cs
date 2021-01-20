using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override Cliente BuscarPorId(int id)
        {
            return _context.Cliente.Include(c => c.Endereços).FirstOrDefault(c => c.Id == id);
        }
    }
}
