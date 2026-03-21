using AutoMapper;
using SolveIt.Common.Generator;
using SolveIt.Application.Statics;
using SolveIt.Common.Security;


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
				dest.EmailActivationCode = CodeGenerator.GenerateActivationEmailCode();
				dest.ExpireEmailActivationCode = DateTime.Now.AddHours(2);
				dest.NormalizedEmail = src.Email?.StringNormalize();
				dest.AvatarAddress = PathTools.DefaultUserAvatar;
			});
		#endregion RegisterViewModel

	}
}
