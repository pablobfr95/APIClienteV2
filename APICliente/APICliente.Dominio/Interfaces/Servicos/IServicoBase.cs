using APICliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<T> where T : EntidadeBase
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
        void Dispose();
    }
}
