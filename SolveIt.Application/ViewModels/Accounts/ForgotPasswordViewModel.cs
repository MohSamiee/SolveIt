using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels.Accounts;
public class ForgotPasswordViewModel
{
	public string? Email { get; set; }


	public string? Mobile { get; set; }


	public DateTime? ExpireMobileVerificationCode { get; set; }


	public string? MobileVerificationCode { get; set; }


	[Display(Name = "EmailOrMobile", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string EmailOrMobile { get; set; }
}

public class ForgotPasswordResponseViewModel
{
	public EmailForgotPasswordResponseViewModel EmailData { get; set; }
	public MobileForgotPasswordResponseViewModel MobileData { get; set; }
	public ForgotPasswordResponseEnum ResponseType { get; set; }
}
public class EmailForgotPasswordResponseViewModel
{
	public string Email { get; set; }
}

public class MobileForgotPasswordResponseViewModel
{
	public string Mobile { get; set; }
	public int CodeLength { get; set; }
	public DateTime ExpireDateTime { get; set; }
}
public enum ForgotPasswordResponseEnum
{
	Mobile,
	Email
}