using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int CPF { get; set; }
        public string Nome { get; set; }
        public string  Senha { get; set; }
        public DateTime DataNasc { get; set; }
        [ForeignKey("PlanosSaude")]
        public virtual PlanosSaude PlanosSaude{ get; set; }
       
        public virtual ICollection<Consulta> Consultas { get; set; }

    }
}