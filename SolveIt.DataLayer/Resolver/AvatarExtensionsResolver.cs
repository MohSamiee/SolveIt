using AutoMapper;
using Microsoft.Extensions.Options;
using SolveIt.Common.ViewModels.Options;

namespace BestShop.Data.Resolver;
public class AvatarExtensionsResolver<TDestination> : IValueResolver<User, TDestination, List<string>>
{
	private readonly FileSetting _avatarSetting;

	public AvatarExtensionsResolver(
		IOptionsSnapshot<FileSetting> fileSettingOptions)
	{
		_avatarSetting = fileSettingOptions.Get(FileTypeEnum.Avatar.ToString());
	}

	public List<string> Resolve(
		User source,
		TDestination destination,
		List<string> destMember,
		ResolutionContext context)
	{
		return
			_avatarSetting.AcceptableExtensions;
	}
}
