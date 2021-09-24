using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjPokeAPI.Data
{
    public class Pokemon
    {
        public int IdPoke { get; set; }
        [Required]
        public string NomePoke { get; set; }
        [Required]
        public string Sprite { get; set; }
        [Required]
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        [Required]
        public int Altura { get; set; }
        [Required]
        public int Peso { get; set; }
    }
}
