using ASP.NET_PROVA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Map
{
    public sealed class PlanosSaudeMap : EntityTypeConfiguration<Paciente>
    {
        public PlanosSaudeMap()
        {
            ToTable("Planos de Saude");
        }


    }
}