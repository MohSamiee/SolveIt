using Microsoft.EntityFrameworkCore;

namespace SolveIt.DataLayer.Context;
public class SolveItDbContext : DbContext
{
	#region Constructor
	public SolveItDbContext(DbContextOptions<SolveItDbContext> options) : base(options)
	{

	}
	#endregion Constructor

	#region DbSets
	public DbSet<User> Users { get; set; }
	#endregion DbSets

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}
