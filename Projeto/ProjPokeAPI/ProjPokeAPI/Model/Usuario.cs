using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjPokeAPI.Data
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
