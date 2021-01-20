using APICliente.Dominio.Validações;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Dominio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade { 
            get{
                if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                    return DateTime.Now.Year - this.DataNascimento.Year - 1;
                else
                    return DateTime.Now.Year - this.DataNascimento.Year;
            }
        }
        

        protected Cliente()
        {

        }

        public Cliente(string nome, string cpf, DateTime dataNascimento)
        {
            ValidarParaInclusao(nome, cpf, dataNascimento);
            Nome = nome;
            Cpf = cpf.Trim().Replace(",","").Replace(".","").Replace("-","");
            DataNascimento = dataNascimento;
        }

        public Cliente(int id, string nome, string cpf, DateTime dataNascimento)
        {
            ValidarParaEdicao(id, nome, cpf, dataNascimento);
            Id = id;
            Nome = nome;
            Cpf = cpf.Trim().Replace(",", "").Replace(".", "").Replace("-", "");
            DataNascimento = dataNascimento;
        }


        private void ValidarParaInclusao(string nome, string cpf, DateTime dataNascimento)
        {
            if (nome.Trim().Length > 30 || nome.Trim().Length == 0) throw new ArgumentException("Nome é obrigatório e possui tamanho máximo de 30 caracteres !");
            if (!ValidadorCPF.CpfValido(cpf)) throw new ArgumentException("Cpf Inválido !");
            if (dataNascimento == DateTime.MinValue || dataNascimento == DateTime.Now) throw new ArgumentException("Data de nascimento é obrigatório !");
           
        }

        private void ValidarParaEdicao(int id, string nome, string cpf, DateTime dataNascimento)
        {
            if (id == 0) throw new ArgumentException("Informe um id !");
            if (nome.Trim().Length > 30 || nome.Trim().Length == 0) throw new ArgumentException("Nome é obrigatório e possui tamanho máximo de 30 caracteres !");
            if (!ValidadorCPF.CpfValido(cpf)) throw new ArgumentException("Cpf Inválido !");
            if (dataNascimento == DateTime.MinValue || dataNascimento >= DateTime.Now) throw new ArgumentException("Data de nascimento é obrigatório !");
        }
    }
}
