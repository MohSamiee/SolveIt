using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels.UserPanel.Accounts;
public class UserPanelUserDataViewModel
{
	[Display(Name  = "FirstName",ResourceType =typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string FirstName { get; set; }


	[Display(Name = "LastName", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string LastName { get; set; }


	[Display(Name = "FullName", ResourceType = typeof(PropertyDictionary))]
	public string? FullName { get; set; }


	public string? ShowName { get; set; }


	[Display(Name = "BirthDate", ResourceType = typeof(PropertyDictionary))]
	public string? BirthDate{ get; set; }


	[Display(Name = "Email", ResourceType = typeof(PropertyDictionary))]
	public string? Email { get; set; }

	
	public bool IsEmailConfirmed { get; set; }


	public bool CanEditEmail { get; set; }


	[Display(Name = "Mobile", ResourceType = typeof(PropertyDictionary))]
	public string? Mobile { get; set; }


	public bool IsMobileConfirmed { get; set; }


	public bool CanEditMobile { get; set; }


	[Display(Name = "City", ResourceType = typeof(PropertyDictionary))]
	public long? CityId{ get; set; }


	[Display(Name = "Country", ResourceType = typeof(PropertyDictionary))]
	public long? CountryId { get; set; }


	[Display(Name = "AboutMe", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(500, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string? AboutMe { get; set; }


	[Display(Name = "JobTitle", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(50, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string? JobTitle { get; set; }


	[Display(Name = "Company", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(50, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string? Company { get; set; }

	[Display(Name = "GetNewsLetter", ResourceType = typeof(PropertyDictionary))]
	public bool GetNewsLetter { get; set; }

	public List<SelectListViewModel>? Countries { get; set; } = new List<SelectListViewModel>();
}
