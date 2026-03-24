using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Areas.UserPanel.Controllers;

public class HomeController : UserPanelBaseController
{

	#region Constructor
	private readonly IUserService _userService;
	private readonly LoginService _loginService;

	public HomeController(IUserService userService, LoginService loginService)
	{
		_userService = userService;
		_loginService = loginService;
	}
	#endregion Constructor

	public IActionResult Index()
	{
		return View();
	}

	#region Change Avatar
	public async Task<IActionResult> ChangeUserAvatar(IFormFile userAvatar)
	{
		var userInfo = _loginService.GetCurrentUserInfo();
		var result = await _userService.ChangeUserAvatar(userInfo!.UserId, userAvatar);
		return Json(result);
	}
	#endregion Change Avatar
}
