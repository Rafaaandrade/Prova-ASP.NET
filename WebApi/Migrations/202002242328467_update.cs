namespace ASP.NET_PROVA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anaminese",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sintomas = c.String(nullable: false),
                        DoençasAnteriores = c.String(nullable: false),
                        PartesCorpo = c.Int(nullable: false),
                        CosultaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultas", t => t.CosultaId)
                .Index(t => t.CosultaId);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataConsulta = c.DateTime(nullable: false),
                        Procedimento = c.String(nullable: false),
                        Horario = c.DateTime(nullable: false),
                        PacienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        CPF = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        DataNasc = c.DateTime(nullable: false),
                        PlanosSaude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anaminese", "CosultaId", "dbo.Consultas");
            DropForeignKey("dbo.Consultas", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Consultas", new[] { "PacienteId" });
            DropIndex("dbo.Anaminese", new[] { "CosultaId" });
            DropTable("dbo.Paciente");
            DropTable("dbo.Consultas");
            DropTable("dbo.Anaminese");
        }
    }
}
