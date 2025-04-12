using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Domain.Dtos.User
{
    public class UserAddDto
    {

        [Required(ErrorMessage = "Campo de preenchimento obrigatório"), MaxLength(100, ErrorMessage = "Quantidade máxima de caracteres atingida")]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "Campo de preenchimento obrigatório"), MaxLength(100, ErrorMessage = "Quantidade máxima de caracteres atingida")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;




        [Required(ErrorMessage = "Campo de preenchimento obrigatório"), MaxLength(20, ErrorMessage = "Quantidade máxima de caracteres atingida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "A senha deve conter pelo menos 8 caracteres, uma letra maiúscula, uma letra minúscula e um número.")]
        [Compare("PasswordConfirm", ErrorMessage = "As senhas devem ser iguais")]
        public string Password { get; set; } = string.Empty;



        [Required(ErrorMessage = "Campo de preenchimento obrigatório"), MaxLength(20, ErrorMessage = "Quantidade máxima de caracteres atingida")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "A senha deve conter pelo menos 8 caracteres, uma letra maiúscula, uma letra minúscula e um número.")]
        [Display(Name = "Senha")]
        [Compare("PasswordConfirm", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirm { get; set; } = string.Empty;

    }
}
