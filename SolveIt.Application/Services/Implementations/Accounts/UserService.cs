using AutoMapper;
using Microsoft.Extensions.Options;
using SolveIt.Common.Generator;
using SolveIt.Common.Security;
using SolveIt.Common.Senders.Sms;
using SolveIt.Common.ViewModels.Options;


namespace SolveIt.Application.Services.Implementations.Accounts;
public class UserService : IUserService
{
	#region Constructor
	private readonly IUserRepository _userRepository;
	private readonly ISmsService _smsService;
	private readonly SmsSetting _smsSetting;
	public IMapper _mapper { get; }
	public UserService(
		IUserRepository userRepository,
		IOptions<SmsSetting> smsSetting,
		IMapper mapper,
		ISmsService smsService)
	{
		_userRepository = userRepository;
		_smsSetting = smsSetting.Value;
		_mapper = mapper;
		_smsService = smsService;
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
				ModelStateError.MakeModelStateError(nameof(register.Email), PropertyDictionary.EmailIsDuplicate));

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

	#region Login
	public async Task<OperationResult<User>> ValidateLogin(LoginViewModel login)
	{
		// Validate model
		var validation = await new ModelVerification().ModelValidation(login);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				validation.ModelStateErrors);

		// Find User
		var users = await _userRepository.GetByValue(login.Email, nameof(login.Email));
		if (users == null)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(nameof(login.Email), PropertyDictionary.LoginInputIsNotValid));

		if (users.Count() > 1)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(nameof(login.Email), PropertyDictionary.ContactAdmin));

		var user = users.First();

		//Check Password
		if (!PasswordHasher.Verify(login.Password, user.HashedPassword))
		{
			user.AccessFailedCount++;
			await _userRepository.UpdateAsync(user, true);
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(nameof(login.Email), PropertyDictionary.LoginInputIsNotValid));
		}

		// Check if is Banned
		if (user.IsBan)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(login.Email), PropertyDictionary.UserIsBan));

		// Check if is Active
		if (!user.IsActive || !user.IsEmailConfirmed)
		{
			// TODO: Send Activation Email Again
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(login.Email), PropertyDictionary.UserIsNotActive));
		}


		// Update User
		user.LastLoginTime = DateTime.Now;
		await _userRepository.UpdateAsync(user, true);

		return new OperationResult<User>(
			true,
			user,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}
	#endregion Login

	#region Activation
	public async Task<OperationResult<User>> ActivateEmail(string activationCode)
	{
		// Find User
		var users = await _userRepository.GetByValue(activationCode, nameof(User.EmailActivationCode));
		if (users == null || users.Count() == 0)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.LoginInputIsNotValid)
				);
		var user = users.First();

		// Check if user Is Banned
		if (user.IsBan)
			return new OperationResult<User>(
				false,
				null,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.UserIsBan)
				);
		//Update User
		user.EmailActivationCode = CodeGenerator.GenerateActivationEmailCode();
		user.IsActive = true;
		user.IsEmailConfirmed = true;
		await _userRepository.UpdateAsync(user, true);

		return new OperationResult<User>(
			true,
			user,
			PropertyDictionary.EmailSuccessfullyActivated,
			StatusResultEnum.Success
			);
	}
	#endregion Activation
}
