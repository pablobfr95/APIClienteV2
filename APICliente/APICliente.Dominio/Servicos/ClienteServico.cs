using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Servicos
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

    }
}
