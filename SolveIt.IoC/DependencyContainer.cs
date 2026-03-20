using Microsoft.Extensions.DependencyInjection;

namespace SolveIt.IoC;
public static class DependencyContainer
{
	public static void RegisterServices(this IServiceCollection services)
	{
	}

	public static void RegisterRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
	}
}
