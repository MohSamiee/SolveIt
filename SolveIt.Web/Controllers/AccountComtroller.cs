using Microsoft.AspNetCore.Mvc;
using SolveIt.Application.Services.Interfaces.Accounts;
using SolveIt.Application.ViewModels.Accounts;

namespace SolveIt.Web.Controllers;
public class AccountController : BaseController
{
	private readonly IUserService _userService;
	#region Constructor
	public AccountController(IUserService userService)
	{
		_userService = userService;
	}
	#endregion Constructor
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

	[HttpPost("Register")]
	public async Task<IActionResult> Register(RegisterViewModel vm)
	{
		if (!ModelState.IsValid)
			return View(vm);

		var result = await _userService.RegisterUser(vm);

		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}
		this.SetOperationMessage(result);
		if (result.IsSuccess) return RedirectToAction("Login", "Account");
		return View(result.Data);
	}
	#endregion Register
}
