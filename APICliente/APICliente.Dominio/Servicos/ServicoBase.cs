using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Servicos
{
    public abstract class ServicoBase<T> : IServicoBase<T> where T : EntidadeBase
    {
        private readonly IRepositorioBase<T> _repositorio;
        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentException(nameof(repositorio));
        }
        public virtual void Adicionar(T entidade) => _repositorio.Adicionar(entidade);


        public virtual void Atualizar(T entidade) => _repositorio.Atualizar(entidade);


        public virtual T BuscarPorId(int id) => _repositorio.BuscarPorId(id);


        public virtual IEnumerable<T> BuscarTodos() => _repositorio.BuscarTodos();


        public virtual void Dispose() => _repositorio.Dispose();


        public virtual void Excluir(T entidade) => _repositorio.Excluir(entidade);
    }
}
