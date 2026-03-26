using Microsoft.Extensions.DependencyInjection;
using SolveIt.Application.Services.Implementations.Locations;
using SolveIt.Application.Services.Interfaces.Locations;

namespace SolveIt.IoC;
public static class DependencyContainer
{
	public static void RegisterServices(this IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<ISmsService, SmsIrService>();
		services.AddScoped<IStateService, StateService>();

	}

	public static void RegisterRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IStateRepository, StateRepository>();
	}
}
