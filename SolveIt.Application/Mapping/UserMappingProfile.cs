using AutoMapper;
using SolveIt.Application.Statics;


namespace SolveIt.Data.Mapping;
public class UserMappingProfile : Profile
{
	public UserMappingProfile()
	{
		#region RegisterViewModel
		CreateMap<RegisterViewModel, User>()
			.AfterMap((src, dest) =>
			{
				dest.Guid = Guid.NewGuid();
				dest.CreatedDate = DateTime.Now;
				dest.HashedPassword = src.Password.Hash();
				dest.EmailActivationCode = !string.IsNullOrWhiteSpace(src.Email) ? CodeGenerator.GenerateActivationEmailCode() : null;
				dest.ExpireEmailActivationCode = !string.IsNullOrWhiteSpace(src.Email) ? DateTime.Now.AddHours(2) : null;
				dest.NormalizedEmail = !string.IsNullOrWhiteSpace(src.Email) ? src.Email?.StringNormalize() : null;
				dest.AvatarAddress = PathTools.DefaultUserAvatar;
				dest.MobileActivationCode = !string.IsNullOrWhiteSpace(src.Mobile) ? CodeGenerator.GenerateMobileCode() : null;
				dest.ExpireMobileActivationCode = !string.IsNullOrWhiteSpace(src.Mobile) ? DateTime.Now.AddSeconds(30) : null;
				dest.IsActive = false;
				dest.IsBan = false;
			});
		#endregion RegisterViewModel

	}
}
