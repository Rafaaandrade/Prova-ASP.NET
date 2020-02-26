using ASP.NET_PROVA.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_PROVA.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Update(TEntity obj);
        void SaveAll();
        void Add(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
    }

    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        public void Dispose()
        {
            ctx.Dispose();
        }

        BaseContext ctx = new BaseContext();

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate) //(x => x.Id == 0)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key) //Id
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Detached(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Detached;
        }

        public void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public virtual void Save(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            ctx.SaveChanges();
        }

        public void SaveAll()
        {
            ctx.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)  //(x => x.Id != 0)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));

            ctx.SaveChanges();
        }
    }
}
