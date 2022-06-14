using Contact.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Contact.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ContactContext ContactContext { get; set; }
        public RepositoryBase(ContactContext contactContext)
        {
            ContactContext = contactContext;
        }
        public IQueryable<T> FindAll() => ContactContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            ContactContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => ContactContext.Set<T>().Add(entity);
        public void Update(T entity) => ContactContext.Set<T>().Update(entity);
        public void Delete(T entity) => ContactContext.Set<T>().Remove(entity);
    }
}
