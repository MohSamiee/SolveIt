using SolveIt.Data.Mapping;

namespace SolveIt.Web.Extensions.Registers;

public static class RegisterOther
{
	public static void RegisterOthers(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
	}
}