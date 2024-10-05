using ePizzaHub.Core;
using ePizzaHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
            TEntity? entity = _appDbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _appDbContext.Set<TEntity>().Remove(entity);
            }
        }

        public TEntity Find(object id)
        {
            return _appDbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }
    }
}
