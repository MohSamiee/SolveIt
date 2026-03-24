using Microsoft.AspNetCore.Mvc;
using SolveIt.Web.Controllers;

public static class ControllerMessageAllertExtension
{
	public static void SetOperationMessage<TEntity>(
		this Controller controller,
		OperationResult<TEntity> result)

	{
		if (result == null || string.IsNullOrWhiteSpace(result.Message))
			return;

		var status = result.Status.ToString();
		if (result.IsSuccess)
			controller.TempData[BaseController.SuccessMessage] = result.Message;

		else if (result.Status == StatusResultEnum.ValidationError)
			controller.TempData[BaseController.ErrorMessage] = null;

		else if (result.Status == StatusResultEnum.AnyOtherError && result.ModelStateErrors != null)
			controller.TempData[BaseController.ErrorMessage] = string.Join(Environment.NewLine, result.ModelStateErrors.Select(a => a.ModelStateErrorMessage).ToList());
	}
}
