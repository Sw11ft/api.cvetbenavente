using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static api.cvetbenavente.Models.Enums;

namespace api.cvetbenavente.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public Genero Genero { get; set; } 
        public int IdEspecie { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdEspecie")]
        public Especie Especie { get; set; }
    }
}
