using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionariosDomain
    {
        public int IdFuncionarios { get; set; }
        [Required(ErrorMessage = "O Nome e Sobrenome do Funcionario é obrigatorio")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
