using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBD.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Valor { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Quantidade { get; set; }
    }
}