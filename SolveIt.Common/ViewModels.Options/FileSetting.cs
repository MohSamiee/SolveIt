namespace SolveIt.Common.ViewModels.Options;
public class FileSetting
{
	public List<string> AcceptableExtensions { get; set; } = [];
	public int MaxFileSizeMb { get; set; }
	public int MaxFileSize => MaxFileSizeMb * 1024 * 1024;
	public List<string> AcceptableContentType { get; set; } = [];

}
