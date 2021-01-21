using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APICliente.Aplicacao.DTO.Validação
{
    public class ValidadorDataNascimentoDTO : ValidationAttribute
    {
        public ValidadorDataNascimentoDTO()
        {
        }

        public override bool IsValid(object value)
        {
            var dateString = value as string;
            DateTime result;
            var success = DateTime.TryParse(dateString, out result);
            if (success)
            {
                if (Convert.ToDateTime(dateString) >= DateTime.Now) return false;
            }
            return success;
        }
    }
}
