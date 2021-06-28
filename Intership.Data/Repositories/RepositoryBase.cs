﻿using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyDbContext RepositoryContext;

        public RepositoryBase(MyDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task CreateAsync(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);

            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);

            await RepositoryContext.SaveChangesAsync();
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

        public async Task UpdateAsync(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);

            await RepositoryContext.SaveChangesAsync();
        }
    }
}