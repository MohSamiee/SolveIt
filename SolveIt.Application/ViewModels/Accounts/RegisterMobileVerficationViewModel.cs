using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels.Accounts;
public class RegisterMobileVerficationViewModel
{
	public int CodeLength { get; set; }
	[Display(Name = "Mobile", ResourceType = typeof(PropertyDictionary))]
	public string Mobile { get; set; }


	[Display(Name = "VerificationCode", ResourceType = typeof(PropertyDictionary))]
	public string VerificationCode { get; set; }


	public DateTime ExpireDateTime { get; set; }
}
