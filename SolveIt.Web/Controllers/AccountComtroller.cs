using Microsoft.AspNetCore.Mvc;
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
	[RedirectHomeIfUserLoggedInActionFiltrer]
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
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
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
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
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

	#region Forgot Password
	[HttpGet("Forgot-Password")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> ForgotPassword()
	{
		return View();
	}


	[HttpPost("Forgot-Password")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
	{
		if (!ModelState.IsValid)
			return View(vm);

		var result = await _userService.ForgotPassword(vm);
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
			if (result.Data!.ResponseType == ForgotPasswordResponseEnum.Email)
				return RedirectToAction("Login", "Account");
			if (result.Data!.ResponseType == ForgotPasswordResponseEnum.Mobile)
			{
				TempData["model"] = JsonSerializer.Serialize(result.Data!.MobileData);

				return RedirectToAction("MobileForgotPasswordVerification", "Account");

			}
		}
		return View(result.Data);
	}


	[HttpGet("Forgot-Password-mobile")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> MobileForgotPasswordVerification()
	{
		try
		{
			var vm = JsonSerializer.Deserialize<MobileForgotPasswordResponseViewModel>(TempData["model"].ToString());
			return View(vm);
		}
		catch (Exception ex)
		{

			return View();
		}
	}

	[HttpPost("Forgot-Password-mobile")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> MobileForgotPasswordVerification(MobileForgotPasswordResponseViewModel vm)
	{
		var result = await _userService.ValidateForgotPasswordMobile(vm);
		this.SetOperationMessage(result);
		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}

		if (!result.IsSuccess)
		{
			if (result.Status != StatusResultEnum.Retry)
				return View(vm);
			else
			{

				TempData["model"] = JsonSerializer.Serialize(result.Data);

				return RedirectToAction("MobileForgotPasswordVerification", "Account");
			}
		}
		return RedirectToAction("ResetPassword", "Account", new
		{
			emailOrMobile = result.Data!.Mobile,
			isForgotPassword = true
		});
	}


	[HttpGet("Forgot-Password-Email/{id}")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> EmailForgotPasswordVerification(string id)
	{
		var result = await _userService.ValidateForgotPasswordEmail(id);

		this.SetOperationMessage(result);
		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}

		if (!result.IsSuccess)
		{
			if (result.Status != StatusResultEnum.Retry)
				return NotFound();
			else
				return RedirectToAction("Login", "Account");
		}

		return RedirectToAction("ResetPassword", "Account", new
		{
			emailOrMobile = result.Data!.Email,
			isForgotPassword = true
		});
	}

	[HttpGet]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> ReSendMobileVerificationCode(string mobile)
	{
		var result = await _userService.ReSendMobileActivationCode(mobile);
		var model = new ForgotPasswordMobileVerficationViewModel
		{
			Mobile = result.Data.Mobile,
			ExpireDateTime = result.Data.ExpireMobileActivationCode!.Value,
			CodeLength = result.Data.MobileActivationCode!.Length
		};
		TempData["model"] = JsonSerializer.Serialize(model);

		return RedirectToAction("MobileForgotPasswordVerification", "Account");
	}

	[HttpGet("reset-password")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> ResetPassword(string emailOrMobile, bool isForgotPassword)
	{
		var result = await _userService.ResetPasswordGetData(emailOrMobile, isForgotPassword);

		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}
		this.SetOperationMessage(result);
		if (!result.IsSuccess)
			return NotFound();

		return View(result.Data);
	}


	[HttpPost("reset-password")]
	[AutoValidateAntiforgeryToken]
	[RedirectHomeIfUserLoggedInActionFiltrer]
	public async Task<IActionResult> ResetPassword(ResetPasswordViewModel vm)
	{
		if (!ModelState.IsValid)
			return View(vm);
		var result = await _userService.ResetPassword(vm);

		this.SetOperationMessage(result);
		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}
		if (!result.IsSuccess)
			return View(vm);

		return Redirect("/");

	}
	#endregion Forgot Password
}