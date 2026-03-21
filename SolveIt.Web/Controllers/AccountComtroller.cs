using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> Login(string returnUrl = "/")
	{
		var login = new LoginViewModel();
		login.ReturnUrl = returnUrl;
		return View(login);
	}

	[HttpPost("Login")]
	[ValidateAntiForgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> Login(LoginViewModel vm)
	{
		if (!ModelState.IsValid)
			return View(vm);

		var result = await _userService.ValidateLogin(vm);

		this.SetOperationMessage(result);

		if (!result.IsSuccess)
			return View(vm);

		await _loginService.LoginUserByCookie(result.Data!, vm.RememberMe);
		return Redirect(vm.ReturnUrl);
	}
	#endregion Login

	#region Register
	[HttpGet("Register")]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> Register()
	{
		return View();
	}

	[HttpPost("Register")]
	[ValidateAntiForgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
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

	#region Logout
	[HttpGet("Logout")]
	public async Task<IActionResult> SignOut()
	{
		await _loginService.LogoutUserByCookie();
		return Redirect("/");
	}
	#endregion Logout
}
