﻿using imagevault.api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace imagevault.api.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly ImageVaultDbContext _context;

	public GenericRepository(ImageVaultDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _context.Set<T>().ToListAsync();
	}

	public async Task<T?> GetByIdAsync(Guid id)
	{
		return await _context.Set<T>().FindAsync(id);
	}

	public async Task AddAsync(T entity)
	{
		await _context.Set<T>().AddAsync(entity);
	}

	public void Update(T entity)
	{
		_context.Set<T>().Update(entity);
	}

	public void Delete(T entity)
	{
		_context.Set<T>().Remove(entity);
	}

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
}