using Microsoft.EntityFrameworkCore;
using SolveIt.DataLayer.SeedData.Locations;

namespace SolveIt.DataLayer.SeedData;
public static class DbSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		SeedState.Seed(modelBuilder);
	}
}
