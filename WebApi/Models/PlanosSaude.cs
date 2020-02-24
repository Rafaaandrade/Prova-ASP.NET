using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Models
{
    [Table("Planos de Saude")]
    public class PlanosSaude
    {
        [Key]
        public int Id { get; set; }
        public int PacienteID { get; set; }

        [ForeignKey("PacienteID")]
       
        public Paciente Paciente { get; set; }

        enum Planos { Unimed, Amil, SaudeServidor, Bradesco  };
    }
}