using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Areas.UserPanel.Controllers;
public class ProfileController : UserPanelBaseController
{
	#region Constructor
	private readonly IUserService _userService;
	private readonly LoginService _loginService;
	public ProfileController(IUserService userService, LoginService loginService)
	{
		_userService = userService;
		_loginService = loginService;
	}
	#endregion Constructor

	#region Edit Profile
	[HttpGet]
	public async Task<IActionResult> EditProfile()
	{
		var userInfo = _loginService.GetCurrentUserInfo();
		var result = await _userService.GetUserData(userInfo!.UserId);
		if (!result.IsSuccess)
			return NotFound();

		return View(result.Data);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> EditProfile(UserPanelUserDataViewModel vm)
	{
		if (!ModelState.IsValid)
		{
			return View(vm);
		}
		var userInfo = _loginService.GetCurrentUserInfo();
		var result = await _userService.UpdateUserProfile(userInfo!.UserId,vm);
		if (!result.IsSuccess)
			return NotFound();

		return View(vm);
	}
	#endregion Edit Profile
}
