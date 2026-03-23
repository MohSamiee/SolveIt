using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveIt.Common.OperationResult;
using System.Text.Json;


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
		if (result.IsSuccess)
		{
			if (!string.IsNullOrWhiteSpace(result.Data!.Email))
				return RedirectToAction("Login", "Account");
			if (!string.IsNullOrWhiteSpace(result.Data!.Mobile))
			{
				var model = new RegisterMobileVerficationViewModel
				{
					Mobile = result.Data.Mobile,
					ExpireDateTime = result.Data.ExpireMobileActivationCode!.Value,
					CodeLength = result.Data.MobileActivationCode!.Length
				};
				TempData["model"] = JsonSerializer.Serialize(model);

				return RedirectToAction("MobileRegisterVerification", "Account");

			}
		}
		return View(result.Data);
	}
	#endregion Register

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

		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}

		this.SetOperationMessage(result);

		if (!result.IsSuccess)
			return View(vm);

		await _loginService.LoginUserByCookie(result.Data!, vm.RememberMe);
		return Redirect(vm.ReturnUrl);
	}
	#endregion Login

	#region Logout
	[HttpGet("Logout")]
	public async Task<IActionResult> SignOut()
	{
		await _loginService.LogoutUserByCookie();
		return Redirect("/");
	}
	#endregion Logout

	#region Activation
	[HttpGet("VerifyEmail/{id}")]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> ActivattionByEmail(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
			return NotFound();
		var result = await _userService.ActivateEmail(id);

		this.SetOperationMessage(result);
		if (!result.IsSuccess && result.Status == StatusResultEnum.NotFound)
			return NotFound();

		return RedirectToAction("Login");

	}

	[HttpGet]
	public async Task<IActionResult> MobileRegisterVerification()
	{
		try
		{
			var vm = JsonSerializer.Deserialize<RegisterMobileVerficationViewModel>(TempData["model"].ToString());
			return View(vm);
		}
		catch (Exception ex)
		{

			return View();
		}
	}

	[HttpPost]
	public async Task<IActionResult> MobileRegisterVerification(RegisterMobileVerficationViewModel vm)
	{
		var result = await _userService.ActivateMobile(vm);
		this.SetOperationMessage(result);

		if (!result.IsSuccess)
		{
			TempData["model"] = JsonSerializer.Serialize(vm);
			return View(vm);
		}

		return RedirectToAction("Login", "Account");
	}

	[HttpGet]
	public async Task<IActionResult> ReSendMobileActivationCode(string mobile)
	{
		var result = await _userService.ReSendMobileActivationCode(mobile);
		var model = new RegisterMobileVerficationViewModel
		{
			Mobile = result.Data.Mobile,
			ExpireDateTime = result.Data.ExpireMobileActivationCode!.Value,
			CodeLength = result.Data.MobileActivationCode!.Length
		};
		TempData["model"] = JsonSerializer.Serialize(model);

		return RedirectToAction("MobileRegisterVerification", "Account");
	}
	#endregion Activation
}
