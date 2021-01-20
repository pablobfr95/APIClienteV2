using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
        void Dispose();
    }
}
