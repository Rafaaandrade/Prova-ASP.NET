using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_PROVA.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DataConsulta { get; set; }

        [Required]
        public string Procedimento { get; set; }

        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }


        public virtual Anaminese Anaminese { get; set; }
    }
}