using APICliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APICliente.Teste.Dominio
{
    public class ClienteTest
    {
        [Theory]
        [InlineData("Nome 1", "09785100030", "11/01/2020")]
        [InlineData("Nome 8", "24490685033", "09/02/1995")]
        [InlineData("Nome 4", "412.897.860-46", "04/01/1998")]
        public void ClienteComDadosValidosParaCadastrarNaoGeraException(string nome, string cpf, string dataNascimentoString)
        {
            var dataNascimento = Convert.ToDateTime(dataNascimentoString);

            var exception = Record.Exception(() => { new Cliente(nome, cpf, dataNascimento); });

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("", "09785100030", "11/01/2020")]
        [InlineData("Nome 8", "", "09/02/1995")]
        [InlineData("Nome 4", "412.897.860-46", "")]
        public void ClienteComDadosInvalidosParaCadastrarGeraException(string nome, string cpf, string dataNascimentoString)
        {
            DateTime dataNascimento;

            if (!DateTime.TryParse(dataNascimentoString, out dataNascimento))
            {
                var exception = Record.Exception(() => { Convert.ToDateTime(dataNascimentoString); });
                Assert.NotNull(exception);
            }
            else
            {
                dataNascimento = Convert.ToDateTime(dataNascimentoString);
                Assert.Throws<ArgumentException>(() => { new Cliente(nome, cpf, dataNascimento); });
            }
        }


        [Theory]
        [InlineData("Nome 1", "09785100030", "11/01/2020", 5)]
        [InlineData("Nome 8", "24490685033", "09/02/1995", 1)]
        [InlineData("Nome 4", "412.897.860-46", "04/01/1998", 4)]
        public void ClienteComDadosValidosParaEditarNaoGeraException(string nome, string cpf, string dataNascimentoString, int id)
        {
            var dataNascimento = Convert.ToDateTime(dataNascimentoString);

            var exception = Record.Exception(() => { new Cliente(id ,nome, cpf, dataNascimento); });

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("", "09785100030", "11/01/2020", 5)]
        [InlineData("Nome 8", "", "09/02/1995", 4)]
        [InlineData("Nome 8", "24490685033", "", 1)]
        [InlineData("Nome 4", "412.897.860-46", "09/02/1995", null)]

        public void ClienteComDadosInvalidosParaEditarGeraException(string nome, string cpf, string dataNascimentoString, int? id)
        {
            DateTime dataNascimento;
            if (!DateTime.TryParse(dataNascimentoString, out dataNascimento))
            {
                var exception = Record.Exception(() => { Convert.ToDateTime(dataNascimentoString); });
                Assert.NotNull(exception);
            }
            else
            {
                dataNascimento = Convert.ToDateTime(dataNascimentoString);
                Assert.Throws<ArgumentException>(() => { new Cliente(Convert.ToInt32(id) ,nome, cpf, dataNascimento ); });
            }
        }
    }
}
