using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Aplicacion.Interface;
using DDD.Dominio.Interface.Services;

namespace DDD.Aplicacion.AppService
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public IQueryable<TEntity> GetAllIQuery()
        {
            return _serviceBase.GetAllIQuery();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IOrderedQueryable<TEntity1> OrderBy<TEntity1>(IQueryable<TEntity1> source, string property)
        {
            return _serviceBase.OrderBy(source, property);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
