using APICliente.Aplicação.DTO;
using APICliente.Aplicação.Interface;
using APICliente.Dominio.Interfaces.Servicos;
using APICliente.Infra.CrossCutting.Adapter.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Aplicação.Servico
{
    public class AppEnderecoServico : IAppEnderecoServico
    {
        private readonly IEnderecoServico _enderecoServico;
        private readonly IMapperEndereco _mapper;

        public AppEnderecoServico(IEnderecoServico enderecoServico, IMapperEndereco mapper)
        {
            _enderecoServico = enderecoServico;
            _mapper = mapper;
        }

        public void Adicionar(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.MapperParaCriarEntidade(enderecoDTO);
            _enderecoServico.Adicionar(endereco);
        }

        public void Atualizar(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.MapperParaEditarouExcluirEntidade(enderecoDTO);
            _enderecoServico.Excluir(endereco);
        }

        public EnderecoDTO BuscarPorId(int id)
        {
            var endereco = _enderecoServico.BuscarPorId(id);
            if (endereco == null) return null;
            return _mapper.MapperParaVisualizarEnderecoDTO(endereco);
        }

        public IEnumerable<EnderecoDTO> BuscarTodos()
        {
            var enderecos = _enderecoServico.BuscarTodos();
            return _mapper.MapperParaVisualizarEnderecosDTO(enderecos);
        }

        public void Excluir(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.MapperParaEditarouExcluirEntidade(enderecoDTO);
            _enderecoServico.Excluir(endereco);
        }
    }
}
