namespace SolveIt.DataLayer.Repositories.Accounts;
public class UserRepository : GenericRepository<User>, IUserRepository
{
	public UserRepository(SolveItDbContext context) : base(context)
	{
	}
}
