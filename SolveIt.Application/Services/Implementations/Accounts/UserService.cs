using AutoMapper;


namespace SolveIt.Application.Services.Implementations.Accounts;
public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	public IMapper _mapper { get; }
	#region Constructor
	public UserService(
		IUserRepository userRepository,
		IMapper mapper
		)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	#endregion Constructor

	#region Register
	public async Task<OperationResult<RegisterViewModel>> RegisterUser(RegisterViewModel register)
	{
		// Validate model
		var validation = await new ModelVerification().ModelValidation(register);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<RegisterViewModel>(
				false, 
				null!, 
				PropertyDictionary.GnSomethingWenWrong, 
				StatusResultEnum.ValidationError,
				validation.ModelStateErrors);

		// Check if email is unique
		if ((await _userRepository.GetByValue(register.Email.StringNormalize(), nameof(User.NormalizedEmail))).Any())
			return new OperationResult<RegisterViewModel>(
				false, 
				register, 
				string.Empty, 
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(register.Email),PropertyDictionary.EmailIsDuplicate));

		// Add User to database
		var user = _mapper.Map<User>(register);
		
		await _userRepository.AddAsync(user, true);
		return new OperationResult<RegisterViewModel>(
			true,
			register,
			PropertyDictionary.RegisterSuccessfullyDoneMessage,
			StatusResultEnum.Success
			
			);
	}

	#endregion Register
}
