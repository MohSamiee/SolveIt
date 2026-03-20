using Microsoft.EntityFrameworkCore;

namespace SolveIt.Web.Extensions.Register
{
	public static class RegisterDatabase
	{
		public static void ConfigDatabase(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<SolveItDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("SolveItConnectionString"));
			});
		}
	}
}
