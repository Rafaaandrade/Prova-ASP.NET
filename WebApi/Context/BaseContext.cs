using ASP.NET_PROVA.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ASP.NET_PROVA.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("name=connectString")
        {

        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Anaminese> Anaminese { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a plularização padrão da nomeclatura das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Configura o formato que um decimal será criado em uma tabela 
            modelBuilder.Properties<decimal>().Configure(x => x.HasPrecision(16, 4));
            modelBuilder.Properties<decimal?>().Configure(x => x.HasPrecision(16, 4));

            base.OnModelCreating(modelBuilder);

            // 1:n Pacientes com muitas consultas
            modelBuilder.Entity<Consulta>().HasRequired(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);// 1:n

            // 1:1 consulta com umas anaminese
            
            modelBuilder.Entity<Anaminese>().HasRequired(x => x.consulta).WithOptional(x => x.Anaminese).Map(m => m.MapKey("CosultaId"));// 1:1
            //modelBuilder.Entity<Consulta>().HasRequired(x => x.Anaminese).WithOptional(x => x.consulta).Map(m => m.MapKey("AnamineseId"));//
        }

    }
}