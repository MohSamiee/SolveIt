using SolveIt.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels.Accounts;
public class RegisterViewModel
{
	[DataType(DataType.EmailAddress, ErrorMessageResourceName = "GnEmailFormatErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string? Email { get; set; }


	[IranMobile]
	public string? Mobile { get; set; }


	[Display(Name = "EmailOrMobile", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string EmailOrMobile { get; set; }


	[Display(Name = "Password", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(50, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	public string Password { get; set; }


	[Display(Name = "RePassword", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	[Compare(nameof(Password), ErrorMessageResourceName = "ComparePasswordErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string RePassword { get; set; }
}

