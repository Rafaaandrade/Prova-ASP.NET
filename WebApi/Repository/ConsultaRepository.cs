using ASP.NET_PROVA.Context;
using ASP.NET_PROVA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_PROVA.Repository
{
    public class ConsultaRepository : Repository<Consulta>
    {
        private List<Consulta> consultas = new List<Consulta>();
        private int _nextId = 1;
        public Consulta Add(Consulta con)
        {
            if(con == null)
            {
                throw new ArgumentNullException("Consultas");
            }
            con.Id = _nextId++;
            consultas.Add(con);

            return con;

        }
        BaseContext ctx = new BaseContext();
        public void Delete(Func<Consulta, bool> predicate)
        {
            ctx.Set<Consulta>().Where(x => x.Id != 0).ToList().
                ForEach(del => ctx.Set<Consulta>().Remove(del));
        }

        public Consulta Find(params object[] id)
        {
            return ctx.Set<Consulta>().Find(id);
        }

        public IQueryable<Consulta> Get(Func<Consulta, bool> predicate)
        {
            return GetAll().Where(c => c.Id == 0).AsQueryable();  
        }

        public IQueryable<Consulta> GetAll()
        {
            return ctx.Set<Consulta>();
        }

        public void SaveAll()
        {
            ctx.SaveChanges();
        }

        public void Update(Consulta con)
        {
            ctx.Entry(con).State = EntityState.Modified;
            ctx.SaveChanges();
        }

    
    }
}