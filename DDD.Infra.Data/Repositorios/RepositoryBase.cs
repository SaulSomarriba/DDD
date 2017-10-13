using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Interface;
using DDD.Dominio.Interface.Repositories;
using DDD.Infra.Data.Contexto;

namespace DDD.Infra.Data.Repositorios
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ModeloContexto Db = new ModeloContexto();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> GetAllIQuery()
        {
            return Db.Set<TEntity>().ToList().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IOrderedQueryable<TEntity1> OrderBy<TEntity1>(IQueryable<TEntity1> source, string property)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
