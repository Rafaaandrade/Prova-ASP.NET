using ASP.NET_PROVA.Context;
using ASP.NET_PROVA.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Repository
{
    public class PacienteRepository : Repository<Paciente>
    {
       
        private List<Paciente> pacientes = new List<Paciente>();
        private int _nextId = 1;
       
        
        public Paciente Add(Paciente pac)
        {
            if(pac == null)
            {
                throw new ArgumentNullException("Paciente");
            }
            pac.Id = _nextId++;
            pacientes.Add(pac);
            return pac;
            
           
        }

        public void Delete(int Id)
        {
            ctx.Set<Paciente>().Where(x => x.Id != 0).ToList()
               .ForEach(del => ctx.Set<Paciente>().Remove(del));

            ctx.SaveChanges();
        }

        BaseContext ctx = new BaseContext();
        public Paciente Find(params object[] id)
        {
            return ctx.Set<Paciente>().Find(id);
        }

        public IQueryable<Paciente> Get(Func<Paciente, bool> predicate)
        {
            return GetAll().Where(p => p.Id == 0);
        }

        public IQueryable<Paciente> GetAll(string nome)
        {
            var paciente = GetAll();
            paciente = paciente.Where(x => x.Nome.Contains(nome));
            return paciente;    
        }

        public void SaveAll()
        {
            ctx.SaveChanges();
        }

        public void Update(Paciente pac)
        {
           
            ctx.Entry(pac).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}