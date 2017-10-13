using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Interface.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIQuery();

        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        IOrderedQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> source, string property);
    }
}
