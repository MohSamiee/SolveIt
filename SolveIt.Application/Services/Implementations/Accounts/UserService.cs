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
		var user = _mapper.Map<User>(register);
		
		await _userRepository.AddAsync(user, true);
		return new OperationResult<RegisterViewModel, RegisterResult>(true, register, string.Empty, RegisterResult.Success);
	}

	#endregion Register
}
