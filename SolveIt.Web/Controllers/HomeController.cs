using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Controllers;
public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
