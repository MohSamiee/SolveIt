using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels.Accounts;
public class LoginViewModel
{
	[Display(Name = "Email", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.EmailAddress, ErrorMessageResourceName = "GnEmailFormatErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string Email { get; set; }


	[Display(Name = "Password", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	public string Password { get; set; }


	[Display(Name = "RememberMe", ResourceType = typeof(PropertyDictionary))]
	public bool RememberMe { get; set; }
}

