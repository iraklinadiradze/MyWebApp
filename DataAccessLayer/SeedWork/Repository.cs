using System.Linq;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.SeedWork
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly CoreDBContext _coreDbContext;

        public Repository(CoreDBContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        IUnitOfWork IRepository<T>.UnitOfWork => throw new System.NotImplementedException();

        public async Task<T> Get(int id)
        {
            return await _coreDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _coreDbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _coreDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _coreDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _coreDbContext.Set<T>().Update(entity);
        }
    }

}
