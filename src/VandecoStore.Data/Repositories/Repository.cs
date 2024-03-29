﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VandecoStore.Core;
using VandecoStore.Data.Context;
using VandecoStore.Domain.Interfaces;

namespace VandecoStore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly ECommerceContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ECommerceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Add(T entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            _dbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
