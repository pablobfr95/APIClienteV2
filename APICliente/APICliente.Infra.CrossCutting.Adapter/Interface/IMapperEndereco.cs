using APICliente.Aplicação.DTO;
using APICliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.CrossCutting.Adapter.Interface
{
    public interface IMapperEndereco
    {
        Endereço MapperParaCriarEndereco(EnderecoDTO enderecoDTO);
        Endereço MapperParaEditarEndereco(EnderecoDTO enderecoDTO);
        EnderecoDTO MapperParaVisualizarEnderecoDTO(Endereço endereco);
        IEnumerable<EnderecoDTO> MapperParaVisualizarEnderecosDTO(IEnumerable<Endereço> enderecos);

    }
}
