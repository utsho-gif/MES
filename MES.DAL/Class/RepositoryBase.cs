using Microsoft.EntityFrameworkCore;
using MES.DAL.Interface;
using MES.Models.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MES.DAL.Class
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MESDbContext RepositoryContext { get; set; }

        public RepositoryBase(MESDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public T FindByID(int id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
