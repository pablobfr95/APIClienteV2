using APICliente.Aplicação.DTO;
using APICliente.Aplicação.Interface;
using APICliente.Dominio.Interfaces.Servicos;
using APICliente.Infra.CrossCutting.Adapter.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Aplicação.Servico
{
    public class AppClienteServico : IAppClienteServico
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMapperCliente _mapper;

        public AppClienteServico(IClienteServico clienteServico, IMapperCliente mapper)
        {
            _clienteServico = clienteServico;
            _mapper = mapper;
        }

        public void Adicionar(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.MapperParaCriarEntidade(clienteDTO);
            _clienteServico.Adicionar(cliente);
        }

        public void Atualizar(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.MapperParaEditarouExcluirEntidade(clienteDTO);
            _clienteServico.Atualizar(cliente);
        }

        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _clienteServico.BuscarPorId(id);
            if (cliente == null) return null;
            return _mapper.MapperParaVisualizarClienteDTO(cliente);
        }

        public IEnumerable<ClienteDTO> BuscarTodos()
        {
            var clientes =_clienteServico.BuscarTodos();
            return _mapper.MapperParaVisualizarClientesDTO(clientes);
        }

        public void Excluir(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.MapperParaEditarouExcluirEntidade(clienteDTO);
            _clienteServico.Excluir(cliente);
        }
    }
}
