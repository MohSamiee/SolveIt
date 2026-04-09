namespace SolveIt.Domain.Interfaces.Locations;
public interface IStateRepository : IGenericRepository<State>
{
	#region Counteries
	Task<List<State>> GetCountries();
	#endregion

	#region Cities
	Task<List<State>> GetCities(long? countryId = 0);
	#endregion Cities

}
