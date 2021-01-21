using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APICliente.Aplicação.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório !")]
        [MaxLength(50, ErrorMessage = "Logradouro possui tamanho máximo de 50 caracteres !")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório !")]
        [MaxLength(40, ErrorMessage = "Bairro possui tamanho máximo de 40 caracteres !")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatório !")]
        [MaxLength(40, ErrorMessage = "Cidade possui tamanho máximo de 40 caracteres !")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório !")]
        [MaxLength(40, ErrorMessage = "Estado possui tamanho máximo de 40 caracteres !")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Informe um cliente para poder adicionar um endereço !")]
        public int ClienteId { get; set; }
        public virtual ClienteDTO Cliente { get; set; }
    }
}
