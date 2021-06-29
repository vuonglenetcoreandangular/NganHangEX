using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VAYTIENNHANH.Data.EF;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore.Query;
using VAYTIENNHANH.Model;

namespace VAYTIENNHANH.Data.Repository
{
    public class Repository<T> : IRepository<T> where T :  BaseEntity
    {
        public VayTienNhanhDbContext _context = null;
        public virtual IQueryable<T> Table => Entities;
        public DbSet<T> table = null;
       // private DbSet<T> _entities;
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (table == null)
                    table = _context.Set<T>();

                return table;
            }
        }
        IQueryable<T> IRepository<T>.TableNoTracking => Entities.AsNoTracking();

        public Repository(VayTienNhanhDbContext _context)
        {
            this._context = _context;
            this.table = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public void Delete(long id)
        {
            var data = table.Find(id);
            table.Remove(data);
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
            Save();
        }

        public async Task<T> GetById(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var entity = includes != null ? includes(table).FirstOrDefault(e => e.Id == id) : Entities.Find(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return entity;
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}