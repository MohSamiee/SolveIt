namespace SolveIt.Web.Extensions.Registers;

public static class RegisterRoute
{
	public static void RegisterRouting(this WebApplication app)
	{
		app.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

		);
		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}"
		).WithStaticAssets();


	}
}

