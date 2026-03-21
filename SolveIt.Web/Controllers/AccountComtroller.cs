using Microsoft.AspNetCore.Mvc;
using SolveIt.Application.Services.Interfaces.Accounts;
using SolveIt.Application.ViewModels.Accounts;
using SolveIt.Web.Extensions;

namespace SolveIt.Web.Controllers;
public class AccountController : BaseController
{
	#region Constructor
	private readonly IUserService _userService;
	private readonly LoginService _loginService;

	public AccountController(IUserService userService, LoginService loginService)
	{
		_userService = userService;
		_loginService = loginService;

	}
	#endregion Constructor

	#region Login
	[HttpGet("Login")]
	public async Task<IActionResult> Login()
	{
		return View();
	}

	[HttpPost("Login")]
	public async Task<IActionResult> Login(LoginViewModel vm)
	{
		if (!ModelState.IsValid)
			return View(vm);

		var result = await _userService.ValidateLogin(vm);

		this.SetOperationMessage(result);

		if (!result.IsSuccess)
			return View(vm);

		await _loginService.LoginUserByCookie(result.Data!, vm.RememberMe);
		return Redirect("/");
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
