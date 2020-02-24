using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Models.Map
{
    public sealed class ConsultaMap : EntityTypeConfiguration<Consulta>
    {
        public ConsultaMap()
        {
            ToTable("Consulta");

            HasKey(x => x.Id).
            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.DataConsulta).HasColumnName("Data Consulta").IsRequired();
            Property(x => x.Horario).HasColumnName("Horario").IsRequired();
            Property(x => x.Procedimento).HasColumnName("Procedimento").IsRequired();
            Property(x => x.Anaminese).HasColumnName("Anaminese").IsRequired();

            HasRequired(x => x.Paciente).WithMany(x => x.Consultas);
        }
    }
}