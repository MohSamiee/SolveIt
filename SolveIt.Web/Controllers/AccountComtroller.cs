using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Controllers;
public class AccountController : BaseController
{
	#region Login
	[HttpGet("Login")]
	public async Task<IActionResult> Login()
	{
		return View();
	}
	#endregion Login

	#region Register
	[HttpGet("Register")]
	public async Task<IActionResult> Register()
	{
		return View();
	}
	#endregion Register
}
