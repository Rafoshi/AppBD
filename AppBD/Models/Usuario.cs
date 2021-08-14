using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBD.Models
{
    public abstract class Usuario
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [RegularExpression(@"^.{11,}$", ErrorMessage = "Digite um CPF válido")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [RegularExpression(@"^.{10,}$", ErrorMessage = "Minímo de 10 número")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NumeroEndereco { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Estado { get; set; }
    }
}