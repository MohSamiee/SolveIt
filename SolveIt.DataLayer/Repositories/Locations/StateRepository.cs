
using Microsoft.EntityFrameworkCore;

namespace SolveIt.DataLayer.Repositories.Accounts;
public class StateRepository : GenericRepository<State>, IStateRepository
{
	public StateRepository(SolveItDbContext context) : base(context)
	{
	}

	#region Countries

	public async Task<List<State>> GetCountries()
	{
		var countryQuery = GetEntity(a => a.ParentId == null);
		return await countryQuery.ToListAsync();
	}
	#endregion Countries

	#region Cities
	public async Task<List<State>> GetCities(long? countryId = 0)
	{
		var cityQuery = GetEntity();
		if ((countryId ?? 0) == 0)
			cityQuery = cityQuery.Where(a => a.ParentId == countryId);
		return await cityQuery.ToListAsync();
	}
	#endregion Cities
}
