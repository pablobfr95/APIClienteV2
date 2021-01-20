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
        public void Adicionar(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public ClienteDTO BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteDTO> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }
    }
}
