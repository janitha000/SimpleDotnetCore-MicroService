using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Context;
using Vehicle.Api.Repository.Generic;
using Vehicle.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vehicle.Api.Repository.UnitOfWork;

namespace Vehicle.Api.Repository
{
    public class CategoryRepository : Repositorybase<Category>, ICategoryRepository
    {
         
        public CategoryRepository(DatabaseContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        public Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteWhere(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> FindBy(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetSingle(string id)
        {
            throw new NotImplementedException();
        }

        public Category GetSingle(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
