using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBD.Models
{
    public class Endereco
    {
        public int ID { get; set; }
        public string Logradaouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }
    }
}