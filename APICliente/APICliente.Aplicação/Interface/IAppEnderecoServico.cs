using APICliente.Aplicação.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Aplicação.Interface
{
    public interface IAppEnderecoServico
    {
        void Adicionar(EnderecoDTO enderecoDTO);
        void Atualizar(EnderecoDTO enderecoDTO);
        void Excluir(EnderecoDTO enderecoDTO);
        EnderecoDTO BuscarPorId(int id);
        IEnumerable<EnderecoDTO> BuscarTodos();
    }
}
