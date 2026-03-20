using BestShop.Common.Generator;
using BestShop.Data.ViewModels;
using SolveIt.Application.Statics;
using SolveIt.Common.Security;

namespace SolveIt.Application.Services.Implementations.Accounts;
public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	#region Constructor
	public UserService(
		IUserRepository userRepository
		)
	{
		_userRepository = userRepository;
	}
	#endregion Constructor

	#region Register
	public async Task<OperationResult<RegisterViewModel, RegisterResult>> RegisterUser(RegisterViewModel register)
	{
		// Validate model
		var validation = await new ModelVerification().ModelValidation(register);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<RegisterViewModel, RegisterResult>(false, null!, "Somethings went wrong", RegisterResult.ModelValidation, validation.ModelStateErrors);

		// Check if email is unique
		if ((await _userRepository.GetByValue(register.Email.StringNormalize(), nameof(User.NormalizedEmail))).Any())
			return new OperationResult<RegisterViewModel, RegisterResult>(false, register, string.Empty, RegisterResult.DuplicateEmail);

		// Add User to database
		var user = new User
		{
			Email = register.Email,
			NormalizedEmail = register.Email.StringNormalize(),
			HashedPassword = register.Password.Hash(),
			EmailActivationCode = CodeGenerator.GenerateActivationEmailCode(),
			AvatarAddress = PathTools.DefaultUserAvatar
		};
		
		await _userRepository.AddAsync(user, true);
		return new OperationResult<RegisterViewModel, RegisterResult>(true, register, string.Empty, RegisterResult.Success);
	}

	#endregion Register
}
