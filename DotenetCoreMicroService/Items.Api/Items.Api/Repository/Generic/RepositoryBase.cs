using Items.Api.Entities;
using Items.Api.Repository.Context;
using Items.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Items.Api.Repository.Generic
{
    public class Repositorybase<T> : IRepositryBase<T> where T : class, IEntityBase, new()
    {
        private DatabaseContext _context;

        public Repositorybase(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            await _context.Set<T>().AddAsync(entity);
            this.Commit();
        }

        public virtual void Commit()
        {
            _context.SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<List<T>> GetAll()
        {
            List<T> entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetSingle(string id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
