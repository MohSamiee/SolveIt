namespace SolveIt.Application.Services.Implementations.Locations;
public class StateService : IStateService
{
	private readonly IStateRepository _stateRepository;
	public StateService(IStateRepository stateRepository)
	{
		_stateRepository = stateRepository;
	}

	public async Task<OperationResult<List<SelectListViewModel>>> GetCuntries()
	{
		var countries = await _stateRepository.GetCountries();

		var res =
			(from country in countries
			 select new SelectListViewModel()
			 {
				 Id = country.Id,
				 Title = country.Title,
			 }).ToList();

		return new OperationResult<List<SelectListViewModel>>(
			true,
			res,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<List<SelectListViewModel>>> GetCities(long? countryId)
	{
		var cities = await _stateRepository.GetCities(countryId);

		var res =
			(from city in cities
			 select new SelectListViewModel()
			 {
				 Id = city.Id,
				 Title = city.Title,
			 }).ToList();

		return new OperationResult<List<SelectListViewModel>>(
			true,
			res,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}
}
