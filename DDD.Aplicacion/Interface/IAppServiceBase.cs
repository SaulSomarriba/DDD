using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Aplicacion.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIQuery();

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        TEntity GetById(int id);

        IOrderedQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> source, string property);
    }
}
