using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Domain.Dtos.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Campo de preenchimento obrigatório"), MaxLength(100, ErrorMessage = "Quantidade máxima de caracteres atingida")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Compare("PasswordConfirm", ErrorMessage = "As senhas devem ser iguais")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo de preenchimento obrigatório"), MaxLength(20, ErrorMessage = "Quantidade máxima de caracteres atingida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Compare("PasswordConfirm", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirm { get; set; } = string.Empty;



    }
}
