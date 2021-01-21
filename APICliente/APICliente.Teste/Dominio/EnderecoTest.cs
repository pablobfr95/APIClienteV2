using APICliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APICliente.Teste.Dominio
{
    public class EnderecoTest
    {
        [Theory]
        [InlineData("rua sei la das contas", "em algum bairro", "em alguma cidade", "em algum estado", 9)]
        [InlineData("rua 2", "centro", "rio de janeiro", "em algum estado", 3)]
        [InlineData("rua nossa senhora", "teste", "em alguma cidade", "rio de janeiro", 2)]
        [InlineData("rua tereza", "em algum bairro", "rio de janeiro", "são paulo", 1)]
        public void EnderecoComDadosValidosParaCadastrarNaoGeraException(string logradouro, string bairro,
            string cidade, string estado, int idCliente)
        {
            var exception = Record.Exception(() => { new Endereço(logradouro, bairro, cidade, estado, idCliente); }) ;
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("", "em algum bairro", "em alguma cidade", "em algum estado", 9)]
        [InlineData("rua 2", "centro", "rio de janeiro", "", 3)]
        [InlineData("rua nossa senhora", "teste", "em alguma cidade", "rio de janeiro", 0)]
        [InlineData("rua tereza", "em algum bairro", "rio de janeiro", "são paulo", null)]
        public void EnderecoComDadosInvalidosParaCadastrarGeraException(string logradouro, string bairro,
            string cidade, string estado, int? idCliente)
        {
            Assert.Throws<ArgumentException>(() => { new Endereço(logradouro, bairro, cidade, estado, Convert.ToInt32(idCliente)); });

        }
    }
}
