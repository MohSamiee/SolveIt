using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Controllers;
public class HomeController : BaseController
{
	public IActionResult Index()
	{
		return View();
	}
}
