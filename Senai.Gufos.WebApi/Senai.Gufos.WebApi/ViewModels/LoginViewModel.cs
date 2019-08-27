using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.ViewModels
{
    public class LoginViewModel
    {
        // Data Annotations
        [Required]
        public string Email { get; set; }
        // Definir o tamanho do campo
        [StringLength(250, MinimumLength = 5)]
        public string Senha { get; set; }
    }
}
