using APICliente.Aplicação.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Aplicação.Interface
{
    public interface IAppClienteServico
    {
        void Adicionar(ClienteDTO clienteDTO);
        void Atualizar(ClienteDTO clienteDTO);
        void Excluir(ClienteDTO clienteDTO);
        ClienteDTO BuscarPorId(int id);
        IEnumerable<ClienteDTO> BuscarTodos();
    }
}
