using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepositoriy<T> where T : BaseEntity
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(Object Id);
        public Task<List<T>> Get(Expression<Func<T, bool>> predicate);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Remove(T entity);
    }
}
