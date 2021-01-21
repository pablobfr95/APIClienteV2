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
    public class EnderecoRepositorio : RepositorioBase<Endereço>, IEnderecoRepositorio
    {
        private readonly APIClienteContext _context;
        public EnderecoRepositorio(APIClienteContext context) : base(context)
        {
            _context = context;
        }

        public override Endereço BuscarPorId(int id)
        {
            return _context.Endereco.Include(e => e.Cliente).AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public override IEnumerable<Endereço> BuscarTodos()
        {
            return _context.Endereco.Include(e => e.Cliente).AsNoTracking();
        }
    }
}
