using ASP.NET_PROVA.Models;
using ASP.NET_PROVA.Models.Map;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("name=connectString")
        {

        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<PlanosSaude> PlanosSaude { get; set; }
        public DbSet<Anaminese> Anaminese { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a plularização padrão da nomeclatura das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Configura o formato que um decimal será criado em uma tabela 
            modelBuilder.Properties<decimal>().Configure(x => x.HasPrecision(16, 4));
            modelBuilder.Properties<decimal?>().Configure(x => x.HasPrecision(16, 4));
            //modelBuilder.Configurations.Add(new Map.PacienteMap());


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Consulta>().HasRequired<Paciente>(p => p.Paciente).WithMany(p => p.Consultas).HasForeignKey(fk => fk.PacienteID);
             //modelBuilder.Entity<Consulta>().HasRequired<Paciente>(p => p.paciente).WithMany(c => c.Consultas).HasForeignKey(p => p.PacienteID);
            //modelBuilder.Entity<Paciente>().HasRequired<Paciente>(c => c.Consultas).WithMany(p => p.paciente).HasForeignKey<int>(c => c.Consultas);
        }

    }
}