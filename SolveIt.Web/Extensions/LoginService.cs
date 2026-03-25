using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace SolveIt.Web.Extensions;

public class LoginService
{
	#region Constructor
	private readonly IHttpContextAccessor _httpContextAccessor;

	public LoginService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}
	#endregion Constructor

	#region Cookie Login
	public async Task LoginUserByCookie(User user, bool rememberMe)
	{
		var claims = SetClaims(user);

		var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var principal = new ClaimsPrincipal(identity);
		var properties = new AuthenticationProperties()
		{
			IsPersistent = rememberMe
		};
		if (_httpContextAccessor.HttpContext != null)
			await _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
	}


	public async Task LogoutUserByCookie()
	{
		if (_httpContextAccessor.HttpContext == null)
			return;
		await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
	}

	public async Task RefreshClaims(User user)
	{
		if (_httpContextAccessor.HttpContext == null)
			return;

		var context = _httpContextAccessor.HttpContext;

		var claims = SetClaims(user);

		var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var principal = new ClaimsPrincipal(identity);

		// گرفتن properties فعلی (برای حفظ RememberMe)
		var authResult = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

		if (!authResult.Succeeded)
			return;

		await context.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			principal,
			authResult.Properties
		);

	}

	#endregion Cookie Login
	public  bool IsUserAuthenticated()
	{
		var status = false;
		if (_httpContextAccessor.HttpContext != null)
			if(_httpContextAccessor.HttpContext.User.Identity != null)
				status = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
		return status;
	}

	public static bool IsUserAuthenticated(ClaimsPrincipal user)
	{
		var status = false;
			if (user.Identity != null)
				status = user.Identity.IsAuthenticated;
		return status;
	}


	public UserInfo? GetCurrentUserInfo()
	{
		if (!IsUserAuthenticated())
			return null;
		var user = _httpContextAccessor.HttpContext!.User;
		var result = GetCurrentUserInfo(user);
		return result;
	}

	public static UserInfo? GetCurrentUserInfo(ClaimsPrincipal user)
	{
		var authenticated = int.TryParse(user.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

		if (IsUserAuthenticated(user))
		{
			var result = new UserInfo()
			{
				UserId = userId,
				Email = user.FindFirstValue(ClaimTypes.Email) ?? "",
				Name = user.FindFirstValue(ClaimTypes.Name) ?? "",
				AvatarPath = user.FindFirstValue(nameof(UserInfo.AvatarPath)) ?? "",
				Mobile = user.FindFirstValue(nameof(UserInfo.Mobile)) ?? "",
			};
			return result;
		}
		return null!;
	}

	private List<Claim> SetClaims(User user)
	{
		var claims = new List<Claim>() 
		{
			new Claim(ClaimTypes.Name,($"{user.FirstName} {user.LastName}")??""),
			new Claim(ClaimTypes.Email, value: user.Email?? string.Empty),
			new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
			new Claim(nameof(UserInfo.AvatarPath),user.AvatarAddress),
			new Claim(nameof(UserInfo.Mobile),user?.Mobile??"")
		};
		return claims;
	}
}

public class UserInfo
{
	public long UserId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string AvatarPath { get; set; }
	public string Mobile { get; set; }
}