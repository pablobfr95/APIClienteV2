using APICliente.Aplicação.DTO;
using APICliente.Dominio.Entidades;
using APICliente.Infra.CrossCutting.Adapter.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.CrossCutting.Adapter.Mappper
{
    public class MapperEndereco : IMapperEndereco
    {
        List<EnderecoDTO> enderecoDTOs = new List<EnderecoDTO>();
        public Endereço MapperParaCriarEntidade(EnderecoDTO enderecoDTO)
        {
            return new Endereço(enderecoDTO.Logradouro, enderecoDTO.Bairro, enderecoDTO.Cidade, enderecoDTO.Estado, enderecoDTO.ClienteId);
        }

        public Endereço MapperParaEditarouExcluirEntidade(EnderecoDTO enderecoDTO)
        {
            return new Endereço(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.Bairro, enderecoDTO.Cidade, enderecoDTO.Estado, enderecoDTO.ClienteId);
        }

        public EnderecoDTO MapperParaVisualizarEnderecoDTO(Endereço endereco)
        {
            return new EnderecoDTO
            {
                Id = endereco.Id,
                Logradouro = endereco.Logradouro,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                ClienteId = endereco.ClienteId,
                Cliente = new ClienteDTO
                {
                    Id = endereco.Cliente.Id,
                    Nome = endereco.Cliente.Nome,
                    Cpf = endereco.Cliente.Cpf,
                    DataNascimento = endereco.Cliente.DataNascimento,
                    Idade = endereco.Cliente.Idade
                }
            };
        }

        public IEnumerable<EnderecoDTO> MapperParaVisualizarEnderecosDTO(IEnumerable<Endereço> enderecos)
        {
            foreach (var item in enderecos)
            {
                EnderecoDTO enderecoDTO = new EnderecoDTO
                {
                    Id = item.Id,
                    Logradouro = item.Logradouro,
                    Bairro = item.Bairro,
                    Cidade = item.Cidade,
                    Estado = item.Estado,
                    ClienteId = item.ClienteId,
                    Cliente = new ClienteDTO
                    {
                        Id = item.Cliente.Id,
                        Nome = item.Cliente.Nome,
                        Cpf = item.Cliente.Cpf,
                        DataNascimento = item.Cliente.DataNascimento,
                        Idade = item.Cliente.Idade
                    }
                };

                enderecoDTOs.Add(enderecoDTO);
            }

            return enderecoDTOs;
        }
    }
}
