using APICliente.Aplicação.DTO;
using APICliente.Dominio.Entidades;
using APICliente.Infra.CrossCutting.Adapter.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.CrossCutting.Adapter.Mappper
{
    public class MapperCliente : IMapperCliente
    {
        List<ClienteDTO> clientesDTO = new List<ClienteDTO>();

        public Cliente MapperParaCriarEntidade(ClienteDTO clienteDTO)
        {
            return new Cliente(clienteDTO.Nome, clienteDTO.Cpf, clienteDTO.DataNascimento);
        }


        public Cliente MapperParaEditarEntidade(ClienteDTO clienteDTO)
        {
            return new Cliente(clienteDTO.Id, clienteDTO.Nome, clienteDTO.Cpf, clienteDTO.DataNascimento);
        }

        public ClienteDTO MapperParaVisualizarClienteDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Idade = cliente.Idade
            };
        }

        public IEnumerable<ClienteDTO> MapperParaVisualizarClientesDTO(IEnumerable<Cliente> clientes)
        {
            foreach (var item in clientes)
            {
                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataNascimento = item.DataNascimento,
                    Idade = item.Idade
                };

                clientesDTO.Add(clienteDTO);
            }
            return clientesDTO;
        }
    }
}
