using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels.Accounts;
public class ResetPasswordViewModel
{
	[Display(Name = "EmailOrMobile", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string EmailOrMobile { get; set; }


	[Display(Name = "OldPassword", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	public string? OldPassword { get; set; }


	[Display(Name = "NewPassword", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	public string NewPassword { get; set; }


	[Display(Name = "ReNewPassword", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	[Compare(nameof(NewPassword), ErrorMessageResourceName = "ComparePasswordErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]

	public string ReBewPassword{ get; set; }


	public bool IsForgotPassword { get; set; }
}
