
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ASP.NET_PROVA.Models.Map
{
    public sealed class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            ToTable("Pacientes");

            HasKey(x => x.Id).Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnName("Nome").IsRequired().HasMaxLength(50);
            Property(x => x.CPF).HasColumnName("CPF").IsRequired(); //.HasMaxLength(11)??//
            Property(x => x.Codigo).HasColumnName("Login").IsRequired();
            Property(x => x.Senha).HasColumnName("Senha").IsRequired();
            Property(x => x.DataNasc).HasColumnName("Data De Nascimento");

            HasRequired(x => x.PlanosSaude).WithRequiredDependent(x => x.Paciente);
            HasMany(c => c.Consultas).WithRequired(x => x.Paciente).HasForeignKey(x => x.PacienteID);
        }
    }
}