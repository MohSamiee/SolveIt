using AutoMapper;
using Microsoft.Extensions.Options;

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
	public async Task<OperationResult<User>> RegisterUser(RegisterViewModel register)
	{
		var isMobile = register.EmailOrMobile.IsIranMobileNumber();
		var isEmail = register.EmailOrMobile.IsEmailAddress();
		if (!isMobile && !isEmail)
			return new OperationResult<User>(
				false,
				null,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(nameof(register.EmailOrMobile), PropertyDictionary.InputEmailOrMobileFormatIsWrong)

				);
		if (isEmail)
			register.Email = register.EmailOrMobile;

		if (isMobile)
			register.Mobile = register.EmailOrMobile;


		// Validate model
		var validation = await new ModelVerification().ModelValidation(register);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				validation.ModelStateErrors);

		// Check if email is unique
		if (isEmail && (await _userRepository.GetByValue(register.Email.StringNormalize(), nameof(User.NormalizedEmail))).Any())
			return new OperationResult<User>(
				false,
				null!,
				string.Empty,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(register.Email), PropertyDictionary.EmailIsDuplicate));

		// Check if Mobile is unique
		if (isMobile && (await _userRepository.GetByValue(register.Mobile, nameof(User.Mobile))).Any())
			return new OperationResult<User>(
				false,
				null!,
				string.Empty,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(register.Mobile), PropertyDictionary.MobileIsDuplicate));


		// Add User to database
		var user = _mapper.Map<User>(register);
		//TODO: Send Activation Message
		//if (isMobile)
			//await _smsService.SendNowToOnePersonSms(_smsSetting, user.MobileActivationCode, user.Mobile);
		await _userRepository.AddAsync(user, true);
		return new OperationResult<User>(
			true,
			user,
			isMobile ? PropertyDictionary.RegisterSuccessfullyDoneMessageForMobile :
			(isEmail ? PropertyDictionary.RegisterSuccessfullyDoneMessageForEmail : ""),
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
		var isMobile = login.EmailOrMobile.IsIranMobileNumber();
		var isEmail = login.EmailOrMobile.IsEmailAddress();

		var users = new List<User>();
		if (isMobile)
			users = await _userRepository.GetByValue(login.EmailOrMobile, nameof(User.Mobile));
		else
			users = await _userRepository.GetByValue(login.EmailOrMobile.StringNormalize(), nameof(User.Email));

		if (users == null)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(nameof(login.EmailOrMobile), PropertyDictionary.LoginInputIsNotValid));

		if (users.Count() > 1)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(nameof(login.EmailOrMobile), PropertyDictionary.ContactAdmin));

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
				ModelStateError.MakeModelStateError(nameof(login.EmailOrMobile), PropertyDictionary.LoginInputIsNotValid));
		}

		// Check if is Banned
		if (user.IsBan)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(login.EmailOrMobile), PropertyDictionary.UserIsBan));

		// Check if is Active
		if (!user.IsActive || (isEmail && !user.IsEmailConfirmed) || (isMobile && !user.IsMobileConfirmed))
		{
			//await _smsService.SendNowToOnePersonSms(_smsSetting, user.MobileActivationCode, user.Mobile);
			// TODO: Send Activation Email Again
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(login.EmailOrMobile), PropertyDictionary.UserIsNotActive));
		}


		// Update User
		user.LastLoginTime = DateTime.Now;
		user.AccessFailedCount = 0;
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

		// Check Expire Time
		if (user.ExpireEmailActivationCode < DateTime.Now)
		{
			user.EmailActivationCode = CodeGenerator.GenerateActivationEmailCode();
			user.ExpireEmailActivationCode = DateTime.Now.AddHours(2);
			await _userRepository.UpdateAsync(user, true);
			//TODO: Send Activation Code Again

			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(user.Email), PropertyDictionary.EmailActivationCodeHasBeenExpired)
				);
		}
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

	public async Task<OperationResult<User>> ActivateMobile(RegisterMobileVerficationViewModel activation)
	{
		// Find User
		var users = await _userRepository.GetByValue(activation.Mobile, nameof(User.Mobile));
		if (users == null || users.Count() == 0)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.LoginInputIsNotValid)
				);
		var user = users.First();

		// Check Activation Code
		if (user.MobileActivationCode != activation.VerificationCode)
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError
				);

		// Check if user Is Banned
		if (user.IsBan)
			return new OperationResult<User>(
				false,
				null,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.UserIsBan)
				);

		// Check Expire Time
		if (user.ExpireEmailActivationCode < DateTime.Now)
		{
			user.MobileActivationCode = CodeGenerator.GenerateMobileCode();
			user.ExpireEmailActivationCode = DateTime.Now.AddMinutes(3);
			await _userRepository.UpdateAsync(user, true);
			//TODO: Send Activation Code Again

			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.Retry,
				ModelStateError.MakeModelStateError(
					nameof(user.Mobile),
					PropertyDictionary.MobileActivationCodeHasBeenExpired)
				);
		}
		//Update User
		user.MobileActivationCode = CodeGenerator.GenerateMobileCode();
		user.IsActive = true;
		user.IsMobileConfirmed = true;
		await _userRepository.UpdateAsync(user, true);

		return new OperationResult<User>(
			true,
			user,
			PropertyDictionary.MobileSuccessfullyActivated,
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<User>> ReSendMobileActivationCode(string mobile)
	{
		var users = await _userRepository.GetByValue(mobile, nameof(User.Mobile));
		if (users == null || !users.Any())
			return new OperationResult<User>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.LoginInputIsNotValid)
				);
		var user = users.First();
		//Update User
		user.MobileActivationCode = CodeGenerator.GenerateMobileCode();
		user.ExpireMobileActivationCode = DateTime.Now.AddSeconds(30);
		await _userRepository.UpdateAsync(user, true);
		//TODO: Send Activation Message

		return new OperationResult<User>(
			true,
			user,
			PropertyDictionary.EmailSuccessfullyActivated,
			StatusResultEnum.Success
			);
	}

	#endregion Activation
}
