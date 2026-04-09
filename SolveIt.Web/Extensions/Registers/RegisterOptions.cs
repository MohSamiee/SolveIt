using SolveIt.Common.Paging;
using SolveIt.Common.ViewModels.Options;

namespace SolveIt.Web.Extensions.Registers;
public static class RegisterOptions
{
	public static void RegisterOptionsInjection(this WebApplicationBuilder builder)
	{
		builder.Services.Configure<PasswordPolicyOptions>(builder.Configuration.GetSection("PasswordPolicy"));

		builder.Services.Configure<FileSetting>(
			FileTypeEnum.Avatar.ToString(),
			builder.Configuration.GetSection("AvatarSetting"));

		builder.Services.Configure<PagingOptions>(builder.Configuration.GetSection("PagingOptions"));

		builder.Services.Configure<SmsSetting>(builder.Configuration.GetSection("SmsIrSetting"));

		builder.Services.Configure<SiteSetting>(builder.Configuration.GetSection("SiteSetting"));
	}
}