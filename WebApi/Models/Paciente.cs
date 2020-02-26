using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_PROVA.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        public int CPF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string  Senha { get; set; }

        [Required]
        public DateTime DataNasc { get; set; }

        [Required]
        public EnumPlanos PlanosSaude { get; set; }


        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}