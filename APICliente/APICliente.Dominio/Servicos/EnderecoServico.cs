using APICliente.Dominio.Entidades;
using APICliente.Dominio.Interfaces.Repositorios;
using APICliente.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Servicos
{
    public class EnderecoServico : ServicoBase<Endereço>, IEnderecoServico
    {
        private readonly IEnderecoRepositorio _repositorio;
        public EnderecoServico(IEnderecoRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
