using Microsoft.AspNetCore.Mvc;
using SolveIt.Application.Services.Interfaces.Locations;

namespace SolveIt.Web.Areas.UserPanel.Controllers;
public class ProfileController : UserPanelBaseController
{
	#region Constructor
	private readonly IUserService _userService;
	private readonly IStateService _stateService;
	private readonly LoginService _loginService;
	public ProfileController(IUserService userService, IStateService stateService, LoginService loginService)
	{
		_userService = userService;
		_loginService = loginService;
		_stateService = stateService;
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
		var result = await _userService.UpdateUserProfile(userInfo!.UserId, vm);
		if (!result.IsSuccess)
			return NotFound();

		return View(vm);
	}
	#endregion Edit Profile

	#region Load Cities
	public async Task<IActionResult> GetCities(long countryId)
	{
		var res =await  _stateService.GetCities(countryId);
		return Json(res);
	}

	#endregion Load Cities
}
