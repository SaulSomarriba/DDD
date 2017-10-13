using DDD.Dominio.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Interface.Repositories;

namespace DDD.Dominio.Servicio
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }


        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<TEntity> GetAllIQuery()
        {
            return _repository.GetAllIQuery();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IOrderedQueryable<TEntity1> OrderBy<TEntity1>(IQueryable<TEntity1> source, string property)
        {
            return _repository.OrderBy(source, property);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
