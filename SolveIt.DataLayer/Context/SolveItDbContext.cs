using Microsoft.EntityFrameworkCore;

namespace SolveIt.DataLayer.Context;
public class SolveItDbContext : DbContext
{
	#region Constructor
	public SolveItDbContext(DbContextOptions<SolveItDbContext> options) : base(options)
	{

	}
	#endregion Constructor
}
