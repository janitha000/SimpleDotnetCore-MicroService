using Vehicle.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vehicle.Api.Repository.Interfaces
{
    public interface IRepositryBase<T> where T : class, IEntityBase, new()
    {
        Task<List<T>> GetAll();
        Task<T> GetSingle(string id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();


    }
}
