namespace SolveIt.Common.ViewModels.Options;
public class SmsSetting
{
	public long LineNumber { get; set; }
	public string ApiKey { get; set; }
}

public enum SendSmsStatus
{
	Success = 1,
	Failed = 2
}
