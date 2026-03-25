namespace SolveIt.Application.ViewModels.UserPanel.Accounts;
public class UserPanelUserDataViewModel
{
	public long Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? FullName { get; set; }
	public string? ShowName { get; set; }
	public DateTime? BirthDate{ get; set; }
	public string? Email { get; set; }
	public string? Mobile { get; set; }
	public long? CityId{ get; set; }
	public long? CountryId { get; set; }
	public string? AboutMe { get; set; }
	public string? JobTitle { get; set; }
	public string? Company { get; set; }
}
