using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Procedimento { get; set; }
        public DateTime Horario { get; set; }
        public string Anaminese { get; set; }

        public int PacienteID { get; set; }
        [ForeignKey("PacienteID")]
      
        public virtual Paciente Paciente { get; set; }
        
        //[ForeignKey]
        //public string paciente_consulta { get; set; }
    }
}