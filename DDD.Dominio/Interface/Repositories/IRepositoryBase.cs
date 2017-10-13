using System.Collections.Generic;
using System.Linq;

namespace DDD.Dominio.Interface.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        

        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIQuery();

        IOrderedQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> source, string property);
    }
}
