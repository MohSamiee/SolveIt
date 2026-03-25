
namespace SolveIt.DataLayer.Repositories.Accounts;
public class StateRepository : GenericRepository<State>, IStateRepository
{
	public StateRepository(SolveItDbContext context) : base(context)
	{
	}
}
