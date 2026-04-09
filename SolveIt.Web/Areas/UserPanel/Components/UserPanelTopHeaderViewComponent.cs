using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Areas.UserPanel.Components;
public class UserPanelTopHeaderViewComponent : ViewComponent
{
	#region Constructor
	private readonly IUserService _userService;
	private readonly LoginService _loginService;

	public UserPanelTopHeaderViewComponent(IUserService userService, LoginService loginService)
	{
		_userService = userService;
		_loginService = loginService;
	}
	#endregion Constructor
	public async Task<IViewComponentResult> InvokeAsync()
	{
		var userInfo = _loginService.GetCurrentUserInfo();
		var res = await _userService.GetUserDataTopHeader(userInfo!.UserId);
		return View(res.Data);
	}
}
