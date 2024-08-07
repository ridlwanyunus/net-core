using Application.Repositories;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal class Repository<T>(SchoolContext _schoolContext) : IRepositoriy<T> where T : BaseEntity
    {
        public async Task Add(T entity)
        {
            await _schoolContext.Set<T>().AddAsync(entity);
        }

        public Task<List<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return _schoolContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _schoolContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(object Id)
        {
            return await _schoolContext.Set<T>().FindAsync(Id);
        }

        public async Task Remove(T entity)
        {
            _schoolContext.Set<T>().Remove(entity);
        }

        public async Task Update(T entity)
        {
            _schoolContext.Set<T>().Update(entity);
        }
    }

}
