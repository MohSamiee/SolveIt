namespace SolveIt.Application.ViewModels.UserPanel.Accounts;
public class UserPanelSidebarViewModel
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? FullName { get; set; }
	public string? Mobile { get; set; }
	public string ShowName { get; set; } = "";
	public string AvatarPath { get; set; } = "";
	public DateTime RegisterDate { get; set; }
	public List<string> AcceptableAvatarExtensions { get; set; }
}
