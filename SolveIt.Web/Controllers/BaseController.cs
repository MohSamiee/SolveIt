using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Controllers;
public class BaseController : Controller{
	public static string SuccessMessage = "SuccessMessage";
	public static string WarningMessage = "WarningMessage";
	public static string InfoMessage = "InfoMessage";
	public static string ErrorMessage = "ErrorMessage";

}

[Authorize]
public class BaseAhtorizeController : BaseController{}