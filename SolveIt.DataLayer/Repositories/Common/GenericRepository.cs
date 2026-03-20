using Microsoft.EntityFrameworkCore;
using SolveIt.Domain.Entities.Common;
using SolveIt.Domain.Interfaces.Accounts;
using System.Linq.Expressions;

namespace SolveIt.DataLayer.Repositories.Common;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
	private readonly SolveItDbContext _context;

	public GenericRepository(SolveItDbContext context)
	{
		_context = context;
	}

	#region Create
	public async Task<TEntity> AddAsync(TEntity entity, bool saveNow = true)
	{
		entity.CreatedDate = DateTime.Now;
		entity.Guid = Guid.NewGuid();
		entity.IsDeleted = false;
		await _context.AddAsync(entity);
		if (saveNow)
			await SaveAsync();
		return entity;
	}

	public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, bool saveNow = true)
	{
		entities.ForEach(a => a.CreatedDate = DateTime.Now);
		entities.ForEach(a => a.Guid = Guid.NewGuid());
		entities.ForEach(a => a.IsDeleted = false);

		_context.AddRange(entities);

		if (saveNow)
			await SaveAsync();
		return entities;
	}
	#endregion Create

	#region Read
	public IQueryable<TEntity> GetEntity(
		Expression<Func<TEntity, bool>>? where = null,
		bool justActive = false,
		bool includeDeleted = false
		)
	{
		IQueryable<TEntity> query = _context.Set<TEntity>();
		if (where != null)
			query = query.Where(where);
		if (justActive)
			query = query.Where(a => a.IsActive);
		if (!includeDeleted)
			query = query.Where(a => !a.IsDeleted);
		return query;
	}

	public IQueryable<TEntity> GetEntityAsNoTracking(
		Expression<Func<TEntity, bool>>? where = null,
		bool justActive = false,
		bool includeDeleted = false
		)
	{
		var query = GetEntity(where, justActive, includeDeleted);
		var res = query.AsNoTracking();
		return res;
	}

	public TEntity? GetById(object id)
	{
		try
		{
			var entity = _context.Set<TEntity>().Find(id);
			return entity;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public async Task<List<TEntity>> GetByValue(object value, string fieldName)
	{
		return await _context.Set<TEntity>()
			.Where(e => EF.Property<object>(e, fieldName).Equals(value)).ToListAsync();
	}

	public IQueryable<TEntity> GetAllAsNoTrack(
		Expression<Func<TEntity, bool>>? filter = null,
		Expression<Func<TEntity, object>>? orderBy = null,
		Expression<Func<TEntity, object>>? orderByDesc = null,
		bool justActive = false,
		bool includeDeleted = false,
		params string[] includeProperties
		)
	{
		IQueryable<TEntity> query = _context.Set<TEntity>();
		if (filter != null)
			query = query.Where(filter);
		if (justActive)
			query = query.Where(a => a.IsActive);
		if (!includeDeleted)
			query = query.Where(a => !a.IsDeleted);

		foreach (var includeProperty in includeProperties)
		{
			foreach (var property in includeProperty.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(property);
			}
		}
		if (orderBy is not null)
		{
			query = query.OrderBy(orderBy);
		}

		if (orderByDesc is not null)
		{
			query = query.OrderByDescending(orderByDesc);
		}
		return query.AsNoTrackingWithIdentityResolution();

	}

	public IQueryable<TEntity> GetAllAsNoTrackWithPaging(
		BasePaging pager,
		IQueryable<TEntity> query,
		Expression<Func<TEntity, object>>? orderBy = null,
		Expression<Func<TEntity, object>>? orderByDesc = null,
		bool justActive = false,
		bool includeDeleted = false
		)
	{
		if (justActive)
			query = query.Where(a => a.IsActive);
		if (!includeDeleted)
			query = query.Where(a => !a.IsDeleted);

		if (orderBy is not null)
		{
			query = query.OrderBy(orderBy);
		}

		if (orderByDesc is not null)
		{
			query = query.OrderByDescending(orderByDesc);
		}

		if (orderBy is null && orderByDesc is null)
		{
			query = query.OrderByDescending(a => a.CreatedDate);
		}
		query = query.Skip(pager.SkipEntity).Take(pager.TakeEntity);
		return query;
	}
	#endregion Read

	#region Update
	public async Task<TEntity> UpdateAsync(TEntity entity, bool saveNow = true)
	{
		entity.LastModifiedDate = DateTime.Now;

		_context.Update(entity);
		if (saveNow)
			await SaveAsync();
		return entity;
	}

	public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities, bool saveNow = true)
	{
		entities.ForEach(a => a.LastModifiedDate = DateTime.Now);
		_context.UpdateRange(entities);
		if (saveNow)
			await SaveAsync();
		return entities;
	}
	#endregion Update

	#region Delete
	public async Task DeleteAsync(TEntity entity, bool hardDelete = false, bool saveNow = true)
	{
		if (hardDelete)
			_context.Remove(entity);
		else
		{
			entity.IsDeleted = true;
			entity.LastModifiedDate = DateTime.Now;
			await UpdateAsync(entity, false);
		}

		if (saveNow)
			await SaveAsync();
	}

	public async Task DeleteAsync(object id, bool hardDelete = false, bool saveNow = false)
	{
		var entity = GetById(id);
		await DeleteAsync(entity, hardDelete, saveNow);
	}

	public async Task DeleteRangeAsync(List<TEntity> entities, bool hardDelete = false, bool saveNow = true)
	{
		if (hardDelete)
			_context.RemoveRange(entities);
		else
		{
			entities.ForEach(a => a.IsDeleted = true);
			entities.ForEach(a => a.LastModifiedDate = DateTime.Now);
			await UpdateRangeAsync(entities, false);
		}
		if (saveNow)
			await SaveAsync();
	}
	#endregion Delete

	#region Save
	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
	#endregion Save
}
