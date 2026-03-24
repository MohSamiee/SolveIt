
using Microsoft.AspNetCore.Mvc;

namespace SolveIt.Web.Areas.UserPanel.Components;
public class UserPanelSidebarViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View();
	}
}
