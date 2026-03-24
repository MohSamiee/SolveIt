using System.Linq.Expressions;

namespace SolveIt.Domain.Interfaces.Accounts;
public interface IGenericRepository<TEntity> where TEntity : class, IEntity
{
	#region Create
	Task<TEntity> AddAsync(TEntity entity, bool saveNow = false);
	Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, bool saveNow = false);
	#endregion Create

	#region Read
	IQueryable<TEntity> GetEntity(
		Expression<Func<TEntity, bool>>? where = null,
		bool justActive = false,
		bool includeDeleted = false
		);
	IQueryable<TEntity> GetEntityAsNoTracking(
		Expression<Func<TEntity, bool>>? where = null,
		bool justActive = false,
		bool includeDeleted = false
		);
	TEntity? GetById(object id);

	Task<List<TEntity>> GetByValue(object value, string fieldName);

	IQueryable<TEntity> GetAllAsNoTrack(
		Expression<Func<TEntity, bool>>? filter = null,
		Expression<Func<TEntity, object>>? orderBy = null,
		Expression<Func<TEntity, object>>? orderByDesc = null,
		bool justActive = false,
		bool includeDeleted = false,
		params string[] includeProperties
		);

	IQueryable<TEntity> GetAllAsNoTrackWithPaging(
		BasePaging pager,
		IQueryable<TEntity> query,
		Expression<Func<TEntity, object>>? orderBy = null,
		Expression<Func<TEntity, object>>? orderByDesc = null,
		bool justActive = false,
		bool includeDeleted = false
		);

	#endregion Read

	#region Update
	Task<TEntity> UpdateAsync(TEntity entity, bool saveNow = false);
	Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities, bool saveNow = false);

	#endregion Update

	#region Delete
	Task DeleteAsync(TEntity entity, bool hardDelete = false, bool saveNow = false);
	Task DeleteAsync(object id, bool hardDelete = false, bool saveNow = false);

	Task DeleteRangeAsync(List<TEntity> entities, bool hardDelete = false, bool saveNow = false);
	#endregion Delete

	#region Save
	Task SaveAsync();
	#endregion Save
}
