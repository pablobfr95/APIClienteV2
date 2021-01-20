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
        public virtual Cliente Cliente { get; set; }

        private void ValidarParaInclusao(string logradouro, string  bairro, string cidade, string estado, Cliente cliente)
        {
            if (string.IsNullOrEmpty(logradouro) || logradouro.Trim().Length > 50) throw new ArgumentException("Logradouro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(bairro) || bairro.Trim().Length > 40) throw new ArgumentException("Bairro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(cidade) || cidade.Trim().Length > 40) throw new ArgumentException("Cidade é obrigatório e tamanho máximo de 40 caracteres !");
            if (string.IsNullOrEmpty(estado) || estado.Trim().Length > 40) throw new ArgumentException("Estado é obrigatório e tamanho máximo de 40 caracteres !");
            if (cliente == null || cliente.Id == 0) throw new ArgumentNullException("Informe um cliente para poder adicionar um endereço !");
        }

        private void ValidarParaEdicao(int id,string logradouro, string bairro, string cidade, string estado, Cliente cliente)
        {
            if (id == 0) throw new ArgumentException("Informe um Id para poder editar o endereço !");
            if (string.IsNullOrEmpty(logradouro) || logradouro.Trim().Length > 50) throw new ArgumentException("Logradouro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(bairro) || bairro.Trim().Length > 40) throw new ArgumentException("Bairro é obrigatório e tamanho máximo de 50 caracteres !");
            if (string.IsNullOrEmpty(cidade) || cidade.Trim().Length > 40) throw new ArgumentException("Cidade é obrigatório e tamanho máximo de 40 caracteres !");
            if (string.IsNullOrEmpty(estado) || estado.Trim().Length > 40) throw new ArgumentException("Estado é obrigatório e tamanho máximo de 40 caracteres !");
            if (cliente == null || cliente.Id == 0) throw new ArgumentNullException("Informe um cliente para poder adicionar um endereço !");
        }
    }
}
