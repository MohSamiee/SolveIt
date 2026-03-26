using AutoMapper;
using SolveIt.Application.Extensions;
using SolveIt.Application.ViewModels.UserPanel.Accounts;
using SolveIt.Common.Converter;

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

		#region User Panel Sidebar
		CreateMap<User, UserPanelSidebarViewModel>()
			.ForMember(d => d.AcceptableAvatarExtensions, o => o.MapFrom<AvatarExtensionsResolver<UserPanelSidebarViewModel>>())
			.ForMember(d => d.AvatarPath, o => o.MapFrom(src => src.AvatarAddress))
			.ForMember(d => d.ShowName, o => o.MapFrom(src => src.GetShowingName()))
			.ForMember(d => d.FirstName, o => o.MapFrom(src => src.FirstName))
			.ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
			.ForMember(d => d.FullName, o => o.MapFrom(src => src.GetFullName()))
			.ForMember(d => d.Email, o => o.MapFrom(src => src.Email))
			.ForMember(d => d.RegisterDate, o => o.MapFrom(src => src.CreatedDate))
			.ForMember(d => d.Mobile, o => o.MapFrom(src => src.Mobile));
		#endregion User Panel Sidebar

		#region User Panel Data
		CreateMap<User, UserPanelUserDataViewModel>()
			.AfterMap((src, dest) =>
			{
				dest.FirstName = src.FirstName;
				dest.LastName = src.LastName;
				dest.FullName = src.GetFullName();
				dest.ShowName = src.GetShowingName();
				dest.BirthDate = src.BirthDate?.ToPersianDate();
				dest.Email = src.Email;
				dest.Mobile = src.Mobile;
				dest.CityId = src.CityId;
				dest.CountryId = src.CountryId;
				dest.AboutMe = src.AboutMe;
				dest.JobTitle = src.JobTitle;
				dest.Company = src.Company;
				dest.IsEmailConfirmed = src.IsEmailConfirmed;
				dest.IsMobileConfirmed = src.IsMobileConfirmed;
				dest.CanEditEmail = (string.IsNullOrWhiteSpace(src.Email));
				dest.CanEditMobile= (string.IsNullOrWhiteSpace(src.Mobile) || !string.IsNullOrWhiteSpace(src.Email));
			});
		#endregion User Panel Data

	}
}