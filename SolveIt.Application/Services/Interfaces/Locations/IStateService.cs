namespace SolveIt.Application.Services.Interfaces.Locations;

public interface IStateService
{
	Task<OperationResult<List<SelectListViewModel>>> GetCuntries();
	Task<OperationResult<List<SelectListViewModel>>> GetCities(long? countryId);
}
