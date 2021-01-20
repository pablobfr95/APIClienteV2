using APICliente.Aplicação.DTO;
using APICliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.CrossCutting.Adapter.Interface
{
    public interface IMapperCliente
    {
        Cliente MapperParaCriarEntidade(ClienteDTO clienteDTO);
        Cliente MapperParaEditarouExcluirEntidade(ClienteDTO clienteDTO);
        ClienteDTO MapperParaVisualizarClienteDTO(Cliente cliente);
        IEnumerable<ClienteDTO> MapperParaVisualizarClientesDTO(IEnumerable<Cliente> clientes);


    }
}
