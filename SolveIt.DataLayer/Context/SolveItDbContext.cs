using Microsoft.EntityFrameworkCore;
using SolveIt.DataLayer.SeedData;

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
	public DbSet<State> States { get; set; }

	#endregion DbSets

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		DbSeeder.Seed(modelBuilder);

	}
}
