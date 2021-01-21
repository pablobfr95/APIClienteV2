using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Entidades
{
    public class Endereço : EntidadeBase
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public int ClienteId { get;private set; }
        public virtual Cliente Cliente { get; set; }

        protected Endereço()
        {

        }

        public Endereço(string logradouro, string bairro, string cidade, string estado, int clienteId)
        {
            ValidarParaInclusao(logradouro, bairro, cidade, estado, clienteId);
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            ClienteId = clienteId;
        }

        public Endereço(int id, string logradouro, string bairro, string cidade, string estado, int clienteId)
        {
            ValidarParaEdicao(id, logradouro, bairro, cidade, estado, clienteId);
            Id = id;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            ClienteId = clienteId;
        }

        private void ValidarParaInclusao(string logradouro, string  bairro, string cidade, string estado, int clienteId)
        {
            if (string.IsNullOrEmpty(logradouro) || logradouro.Trim().Length > 50) throw new ArgumentException("Logradouro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(bairro) || bairro.Trim().Length > 40) throw new ArgumentException("Bairro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(cidade) || cidade.Trim().Length > 40) throw new ArgumentException("Cidade é obrigatório e tamanho máximo de 40 caracteres !");
            if (string.IsNullOrEmpty(estado) || estado.Trim().Length > 40) throw new ArgumentException("Estado é obrigatório e tamanho máximo de 40 caracteres !");
            if (clienteId == 0 ) throw new ArgumentException("Informe um cliente para poder adicionar um endereço !");
        }

        private void ValidarParaEdicao(int id,string logradouro, string bairro, string cidade, string estado, int clienteId)
        {
            if (id == 0) throw new ArgumentException("Informe um Id para poder editar o endereço !");
            if (string.IsNullOrEmpty(logradouro) || logradouro.Trim().Length > 50) throw new ArgumentException("Logradouro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(bairro) || bairro.Trim().Length > 40) throw new ArgumentException("Bairro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(cidade) || cidade.Trim().Length > 40) throw new ArgumentException("Cidade é obrigatório e tamanho máximo de 40 caracteres !");
            if (string.IsNullOrEmpty(estado) || estado.Trim().Length > 40) throw new ArgumentException("Estado é obrigatório e tamanho máximo de 40 caracteres !");
            if (clienteId == 0) throw new ArgumentException("Informe um cliente para poder adicionar um endereço !");
        }
    }
}
