using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Servicos
{
    public class ServicoBase<T> : IServicoBase<T> where T : EntidadeBase
    {
        private readonly IRepositorioBase<T> _repositorio;
        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentException(nameof(repositorio));
        }
        public void Adicionar(T entidade) => _repositorio.Adicionar(entidade);


        public void Atualizar(T entidade) => _repositorio.Atualizar(entidade);


        public T BuscarPorId(int id) => _repositorio.BuscarPorId(id);


        public IEnumerable<T> BuscarTodos() => _repositorio.BuscarTodos();


        public void Dispose() => _repositorio.Dispose();


        public void Excluir(T entidade) => _repositorio.Excluir(entidade);
    }
}
