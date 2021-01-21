using APICliente.Aplicação.DTO;
using APICliente.Aplicação.Interface;
using APICliente.Dominio.Interfaces.Servicos;
using APICliente.Infra.CrossCutting.Adapter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APICliente.Aplicação.Servico
{
    public class AppClienteServico : IAppClienteServico
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMapperCliente _mapperCliente;
        private readonly IMapperEndereco _mapperEndereco;

        public AppClienteServico(IClienteServico clienteServico, IMapperCliente mapperCliente, IMapperEndereco mapperEndereco)
        {
            _clienteServico = clienteServico;
            _mapperCliente = mapperCliente;
            _mapperEndereco = mapperEndereco;
        }

        public void Adicionar(ClienteDTO clienteDTO)
        {
            var cliente = _mapperCliente.MapperParaCriarEntidade(clienteDTO);
            _clienteServico.Adicionar(cliente);
        }

        public void Atualizar(ClienteDTO clienteDTO)
        {
            var cliente = _mapperCliente.MapperParaEditarouExcluirEntidade(clienteDTO);
            _clienteServico.Atualizar(cliente);
        }

        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _clienteServico.BuscarPorId(id);
            if (cliente == null) return null;
            var clienteDTO = _mapperCliente.MapperParaVisualizarClienteDTO(cliente);
            clienteDTO.EndereçosDTO = _mapperEndereco.MapperParaVisualizarEnderecosDTO(cliente.Endereços);
            return clienteDTO;
        }

        public IEnumerable<ClienteDTO> BuscarTodos()
        {
            var clientes =_clienteServico.BuscarTodos();
            var clientesDTO = _mapperCliente.MapperParaVisualizarClientesDTO(clientes);
            foreach (var item in clientesDTO)
            {
                item.EndereçosDTO = _mapperEndereco.MapperParaVisualizarEnderecosDTO(clientes.FirstOrDefault(c => c.Id == item.Id).Endereços);
            }
            return clientesDTO;
        }

        public void Excluir(ClienteDTO clienteDTO)
        {
            var cliente = _mapperCliente.MapperParaEditarouExcluirEntidade(clienteDTO);
            _clienteServico.Excluir(cliente);
        }
    }
}
