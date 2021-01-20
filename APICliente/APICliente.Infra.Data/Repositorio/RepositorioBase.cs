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
    public abstract class RepositorioBase<T> : IDisposable, IRepositorioBase<T> where T : EntidadeBase
    {

        private readonly APIClienteContext _context;

        public RepositorioBase(APIClienteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual void Adicionar(T entidade)
        {
            _context.Set<T>().Add(entidade);
            _context.SaveChanges();

        }

        public virtual void Atualizar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual T BuscarPorId(int id) => _context.Set<T>().FirstOrDefault(t => t.Id == id);


        public virtual IEnumerable<T> BuscarTodos() => _context.Set<T>().ToList();
        

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Excluir(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            _context.SaveChanges();
        }
    }
}
