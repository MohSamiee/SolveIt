namespace SolveIt.Application.Extensions;
public static class UserExtensions
{
	public static string GetShowingName(this User user)
	{
		var res = string.Empty;
		if (!string.IsNullOrWhiteSpace(user.FirstName) || !string.IsNullOrWhiteSpace(user.LastName))
			res = user.GetFullName();
		else if (!string.IsNullOrWhiteSpace(user.Email))
			res = user.Email.Split("@")[0];
		else if (!string.IsNullOrWhiteSpace(user.Mobile))
			res = user.Mobile;
		return res;
	}

	public static string GetFullName(this User user)
	{
		var res = string.Empty;
		if (!string.IsNullOrWhiteSpace(user.FirstName) || !string.IsNullOrWhiteSpace(user.LastName))
			res = $"{user.FirstName} {user.LastName}".Trim();
		return res;
	}
}
