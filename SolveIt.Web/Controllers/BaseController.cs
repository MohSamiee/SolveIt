using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Controllers;
public class BaseController : Controller{}

[Authorize]
public class BaseAhtorizeController : BaseController{}