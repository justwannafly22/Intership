﻿using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intership.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyDbContext RepositoryContext;

        public RepositoryBase(MyDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);

            RepositoryContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);

            RepositoryContext.SaveChangesAsync();
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            RepositoryContext.Set<T>()
                .AsNoTracking() :
            RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            RepositoryContext.Set<T>()
                .Where(expression);

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);

            RepositoryContext.SaveChangesAsync();
        }

    }
}
