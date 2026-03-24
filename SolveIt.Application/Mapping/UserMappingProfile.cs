using AutoMapper;
using SolveIt.Application.Extensions;

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

		#region User Pnael
		CreateMap<User, UserPanelSidebarViewModel>()
			.AfterMap((src, dest) =>
			{
				dest.RegisterDate = src.CreatedDate;
				dest.AvatarPath = src.AvatarAddress;
				dest.ShowName = src.GetShowingName();
				dest.FirstName = src.FirstName;
				dest.LastName = src.LastName;
				dest.FullName = src.GetFullName();
				dest.Email = src.Email;
				dest.Mobile = src.Mobile;
	});
		#endregion User Pnael
	}
}
