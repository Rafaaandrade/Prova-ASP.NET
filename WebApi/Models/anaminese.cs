using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Models
{
    public class Anaminese
    {
        [Key]
        public int Id { get; set; }
        public string Sintomas { get; set; }
        public string DoençasAnteriores { get; set; }
        enum PartesCorpo { Cabeça, Abdomen, Membros_superiores, Membros_inferiores}
    }
}  