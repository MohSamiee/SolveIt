namespace SolveIt.Application.Statics;
public static class PathTools
{
	#region User
	public static readonly string DefaultUserAvatar = "DefaultAvatar.PNG";
	public static readonly string AvatarPath = "/content/user-avatar/";
	public static readonly string AvatarServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/user-avatar/");
	#endregion User
}
