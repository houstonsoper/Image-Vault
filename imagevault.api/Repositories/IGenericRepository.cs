﻿namespace imagevault.api.Repositories;

public interface IGenericRepository<T> where T : class
{
	Task <IEnumerable<T>> GetAllAsync();
	IQueryable<T> GetAllQuery();
	Task<T?> GetByIdAsync(Guid id);
	Task AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
	Task SaveAsync();
}