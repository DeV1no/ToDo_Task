﻿using Microsoft.EntityFrameworkCore;
using ToDo_Task_DataAccess;
using ToDo_Task_Repository.IRepositories;

namespace ToDo_Task_Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<List<T>> All()
        => await _dbSet.ToListAsync();


    public virtual async Task<T?> GetById(int id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<T> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> Delete(int id)
    {
        var entity = await GetById(id);
        if (entity is null)
            throw new Exception($"{id} is not found");
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> Update(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    
}