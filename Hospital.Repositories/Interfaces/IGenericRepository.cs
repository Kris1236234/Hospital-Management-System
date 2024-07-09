using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hospital.Repositories.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteAsync(T entity);
        void Add(object timing);

        int Count(Expression<Func<T, bool>> filter = null);
        bool Any(Expression<Func<T, bool>> filter = null);
        void DeleteRange(IEnumerable<T> entities);
        void BulkInsert(IEnumerable<T> entities);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

     
         

   
     }
}
