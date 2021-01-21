using APICliente.Aplicacao.DTO.Validação;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APICliente.Aplicação.DTO
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Nome possui tamanho máximo de 30 caracteres !")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Cpf é obrigátorio !")]
        [ValidadorCpfDTO(ErrorMessage = "Cpf Inválido !")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Data Nascimento Obrigatório !")]
        [ValidadorDataNascimentoDTO(ErrorMessage = "Data Nascimento Inválida !")]
        public string DataNascimento { get; set; }
        public int Idade { get; set; }
        public virtual IEnumerable<EnderecoDTO> EndereçosDTO { get; set; }
    }
}
