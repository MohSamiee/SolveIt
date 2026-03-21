using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Controllers;
public class HomeController : BaseController
{
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet("NotFound")]
	public async Task<IActionResult> NotFound()
	{
		return View();
	}
}
