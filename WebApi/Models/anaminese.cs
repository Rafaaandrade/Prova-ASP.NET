using System.ComponentModel.DataAnnotations;

namespace ASP.NET_PROVA.Models
{
    public class Anaminese
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Sintomas { get; set; }

        [Required]
        public string DoençasAnteriores { get; set; }

        [Required]
        public EnumPartesCorpo PartesCorpo { get; set; }


        public virtual Consulta consulta { get; set; }
    }
}  