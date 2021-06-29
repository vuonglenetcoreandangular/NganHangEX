using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAYTIENNHANH.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> TableNoTracking { get; }
        Task<List<T>> GetAll();

        Task<T> GetById(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        void Insert(T obj);

        void Update(T obj);

        void Delete(long id);

        void Delete(T obj);

        void Save();
    }
}