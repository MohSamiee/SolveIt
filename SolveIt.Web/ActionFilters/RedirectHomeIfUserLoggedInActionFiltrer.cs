using Microsoft.AspNetCore.Mvc.Filters;

namespace SolveIt.Web.ActionFilters;

public class RedirectHomeIfUserLoggedInActionFiltrer:ActionFilterAttribute
{
	public override void OnActionExecuting(ActionExecutingContext context)
	{
		base.OnActionExecuting(context);
		if (LoginService.IsUserAuthenticated(context.HttpContext.User))
			context.HttpContext.Response.Redirect("/");
	}
}
