using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SolveIt.Application.Services.Implementations.Accounts;
public class UserService : IUserService
{
	#region Constructor
	private readonly IUserRepository _userRepository;
	private readonly IStateRepository _stateRepository;

	private readonly IStateService _stateService;

	private readonly SiteSetting _siteSettings;
	private readonly FileSetting _avatarSetting;

	private readonly IMapper _mapper;

	public UserService(
		IUserRepository userRepository,
		IStateRepository stateRepository,

		IStateService stateService,

		IOptions<SiteSetting> siteSettings,
		IOptionsSnapshot<FileSetting> fileSettingOptions,

		IMapper mapper
		)
	{
		_userRepository = userRepository;
		_stateRepository = stateRepository;

		_stateService = stateService;

		_siteSettings = siteSettings.Value;
		_avatarSetting = fileSettingOptions.Get(FileTypeEnum.Avatar.ToString());

		_mapper = mapper;
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
			user.ExpireEmailActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireEmailCodeInMinutes);
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

	public async Task<OperationResult<RegisterMobileVerficationViewModel>> ActivateMobile(RegisterMobileVerficationViewModel activation)
	{
		// Find User
		var users = await _userRepository.GetByValue(activation.Mobile, nameof(User.Mobile));
		if (users == null || users.Count() == 0)
			return new OperationResult<RegisterMobileVerficationViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.LoginInputIsNotValid)
				);
		var user = users.First();
		activation.VerificationCode = user.MobileActivationCode!;
		// Check Activation Code
		if (user.MobileActivationCode != activation.VerificationCode)
			return new OperationResult<RegisterMobileVerficationViewModel>(
				false,
				activation,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError
				);

		// Check if user Is Banned
		if (user.IsBan)
			return new OperationResult<RegisterMobileVerficationViewModel>(
				false,
				activation,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(nameof(User.Email), PropertyDictionary.UserIsBan)
				);

		// Check Expire Time
		if (user.ExpireEmailActivationCode < DateTime.Now)
		{
			user.MobileActivationCode = CodeGenerator.GenerateMobileCode();
			user.ExpireMobileActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireSmsCodeInMinutes);
			await _userRepository.UpdateAsync(user, true);
			//TODO: Send Activation Code Again

			return new OperationResult<RegisterMobileVerficationViewModel>(
				false,
				activation,
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

		return new OperationResult<RegisterMobileVerficationViewModel>(
			true,
			activation,
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
		user.ExpireMobileActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireSmsCodeInMinutes);
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

	#region Forgot Password
	public async Task<OperationResult<ForgotPasswordResponseViewModel>> ForgotPassword(ForgotPasswordViewModel forgot)
	{
		ForgotPasswordResponseViewModel result = new();

		var isMobile = forgot.EmailOrMobile.IsIranMobileNumber();
		var isEmail = forgot.EmailOrMobile.IsEmailAddress();

		var validation = await new ModelVerification().ModelValidation(result);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<ForgotPasswordResponseViewModel>(
				false,
				result,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				validation.ModelStateErrors);


		if (!isMobile && !isEmail)
			return new OperationResult<ForgotPasswordResponseViewModel>
			(
				false,
				result,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(
					nameof(forgot.EmailOrMobile),
					PropertyDictionary.InputEmailOrMobileFormatIsWrong
					)
			);

		var users = new List<User>();

		if (isMobile)
		{
			result.ResponseType = ForgotPasswordResponseEnum.Mobile;
			result.MobileData!.Mobile = forgot.EmailOrMobile;
			users = await _userRepository.GetByValue(forgot.EmailOrMobile, nameof(User.Mobile));
		}

		else if (isEmail)
		{
			result.ResponseType = ForgotPasswordResponseEnum.Email;
			result.EmailData!.Email = forgot.EmailOrMobile;
			users = await _userRepository.GetByValue(forgot.EmailOrMobile.Trim().StringNormalize(), nameof(User.NormalizedEmail));
		}


		if (users == null || !users.Any())
			return new OperationResult<ForgotPasswordResponseViewModel>(
				false,
				result,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound,
				ModelStateError.MakeModelStateError(
					nameof(forgot.EmailOrMobile),
					PropertyDictionary.LoginInputIsNotValid
					)
				);

		var user = users.First();
		if (user.IsBan)
			return new OperationResult<ForgotPasswordResponseViewModel>(
				false,
				result,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(
					nameof(forgot.EmailOrMobile),
					PropertyDictionary.UserIsBan
					)
				);

		if (isMobile)
		{
			user.MobileActivationCode = CodeGenerator.GenerateMobileCode();
			user.ExpireMobileActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireSmsCodeInMinutes);

			result.MobileData!.ExpireDateTime = user.ExpireMobileActivationCode.Value;
			result.MobileData!.CodeLength = user.MobileActivationCode!.Length;
		}
		if (isEmail)
		{
			user.EmailActivationCode = CodeGenerator.GenerateActivationEmailCode();
			user.ExpireEmailActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireEmailCodeInMinutes);
		}
		await _userRepository.UpdateAsync(user, true);
		return new OperationResult<ForgotPasswordResponseViewModel>(
			true,
			result,
			isMobile ? PropertyDictionary.ResetPasswordVerificationCodeSentByMobile :
			(isEmail ? PropertyDictionary.ResetPasswordLinkSentByEmail : ""),
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<MobileForgotPasswordResponseViewModel>> ValidateForgotPasswordMobile(MobileForgotPasswordResponseViewModel validation)
	{

		var modelValidation = await new ModelVerification().ModelValidation(validation);
		if (!modelValidation.IsSuccess && modelValidation.ModelStateErrors != null && modelValidation.ModelStateErrors.Any())
			return new OperationResult<MobileForgotPasswordResponseViewModel>(
				false,
				validation,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				modelValidation.ModelStateErrors);

		var users = await _userRepository.GetByValue(validation.Mobile, nameof(User.Mobile));

		if (users == null || !users.Any())
			return new OperationResult<MobileForgotPasswordResponseViewModel>(
				false,
				validation,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		var user = users.First();

		if (user.MobileActivationCode != validation.VerificationCode)
			return new OperationResult<MobileForgotPasswordResponseViewModel>(
				false,
				validation,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.Retry);

		if (user.ExpireEmailActivationCode < DateTime.Now)
		{
			user.MobileActivationCode = CodeGenerator.GenerateMobileCode();
			user.ExpireEmailActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireSmsCodeInMinutes);
			validation.CodeLength = user.MobileActivationCode.Length;
			validation.ExpireDateTime = user.ExpireEmailActivationCode.Value;
			await _userRepository.UpdateAsync(user, true);
			//TODO: Send Activation Code Again

			return new OperationResult<MobileForgotPasswordResponseViewModel>(
				false,
				validation,
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

		return new OperationResult<MobileForgotPasswordResponseViewModel>(
			true,
			validation,
			PropertyDictionary.MobileSuccessfullyActivated,
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<EmailForgotPasswordResponseViewModel>> ValidateForgotPasswordEmail(string emailCode)
	{
		if (string.IsNullOrWhiteSpace(emailCode))
			return new OperationResult<EmailForgotPasswordResponseViewModel>(
				false,
				null,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound
				);

		var users = await _userRepository.GetByValue(emailCode, nameof(User.EmailActivationCode));
		if (users == null || !users.Any())
			return new OperationResult<EmailForgotPasswordResponseViewModel>(
				false,
				null,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound
				);

		var user = users.First();

		var result = new EmailForgotPasswordResponseViewModel()
		{
			Email = user.Email!
		};

		if (user.ExpireEmailActivationCode < DateTime.Now)
		{
			user.EmailActivationCode = CodeGenerator.GenerateActivationEmailCode();
			user.ExpireEmailActivationCode = DateTime.Now.AddMinutes(_siteSettings.ExpireEmailCodeInMinutes);
			await _userRepository.UpdateAsync(user, true);

			return new OperationResult<EmailForgotPasswordResponseViewModel>(
				false,
				result,
				PropertyDictionary.EmailActivationCodeHasBeenExpired,
				StatusResultEnum.Retry
				);
		}

		user.EmailActivationCode = CodeGenerator.GenerateActivationEmailCode();
		user.IsActive = true;
		user.IsEmailConfirmed = true;
		await _userRepository.UpdateAsync(user, true);
		return new OperationResult<EmailForgotPasswordResponseViewModel>(
			true,
			result,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}
	public async Task<OperationResult<ResetPasswordViewModel>> ResetPasswordGetData(string emailOrMobile, bool isForgotPassword)
	{
		if (string.IsNullOrWhiteSpace(emailOrMobile))
			return new OperationResult<ResetPasswordViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError
				);

		var isMobile = emailOrMobile.IsIranMobileNumber();
		var isEmail = emailOrMobile.IsEmailAddress();
		var users = new List<User>();

		users = isMobile ? await _userRepository.GetByValue(emailOrMobile, nameof(User.Mobile)) :
			(isEmail ? await _userRepository.GetByValue(emailOrMobile.Trim().StringNormalize(), nameof(User.Email)) : new());

		if (users == null || !users.Any())
			return new OperationResult<ResetPasswordViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError
				);

		var user = users.First();

		var result = new ResetPasswordViewModel()
		{
			EmailOrMobile = emailOrMobile,
			IsForgotPassword = isForgotPassword,
		};
		return new OperationResult<ResetPasswordViewModel>(

			true,
			result,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}
	public async Task<OperationResult<bool>> ResetPassword(ResetPasswordViewModel reset)
	{

		var validation = await new ModelVerification().ModelValidation(reset);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				validation.ModelStateErrors);

		var isMobile = reset.EmailOrMobile.IsIranMobileNumber();
		var isEmail = reset.EmailOrMobile.IsEmailAddress();

		var users = isMobile ? await _userRepository.GetByValue(reset.EmailOrMobile, nameof(User.Mobile)) :
			(isEmail ? await _userRepository.GetByValue(reset.EmailOrMobile.Trim().StringNormalize(), nameof(User.Email)) : new());

		if (users == null || !users.Any())
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError
				);
		var user = users.First();

		if (!reset.IsForgotPassword)
		{
			if (string.IsNullOrWhiteSpace(reset.OldPassword))
			{
				return new OperationResult<bool>(
					false,
					false,
					PropertyDictionary.GnSomethingWenWrong,
					StatusResultEnum.ValidationError,
					ModelStateError.MakeModelStateError(
						nameof(reset.OldPassword),
						string.Format(PropertyDictionary.GnRequiredErrorMessage, PropertyDictionary.OldPassword)
						)
					);
			}
			if (!PasswordHasher.Verify(reset.OldPassword, user.HashedPassword))
				return new OperationResult<bool>(
					false,
					false,
					PropertyDictionary.GnSomethingWenWrong,
					StatusResultEnum.ValidationError,
					ModelStateError.MakeModelStateError(
						nameof(reset.OldPassword),
						PropertyDictionary.IncorrectPassword)
					);
		}
		user.HashedPassword = reset.NewPassword.Hash();
		await _userRepository.UpdateAsync(user, true);
		return new OperationResult<bool>(
			true,
			true,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}

	#endregion Forgot Password

	#region User Panel
	public async Task<OperationResult<UserPanelSidebarViewModel>> GetUserForSidebarPanel(long userId)
	{
		var user = _userRepository.GetById(userId);
		if (user == null)
			return new OperationResult<UserPanelSidebarViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.NotFound
				);

		var res = _mapper.Map<UserPanelSidebarViewModel>(user);
		res.AcceptableAvatarExtensions = _avatarSetting.AcceptableExtensions;
		return new OperationResult<UserPanelSidebarViewModel>(
			true,
			res,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<bool>> ChangeUserAvatar(long userId, IFormFile avatar)
	{
		var user = _userRepository.GetById(userId);
		if (user == null)
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));
		var avatarValidation = new FileValidation().IsValidFile(avatar, _avatarSetting, true);
		if (!avatarValidation.IsSuccess)
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				avatarValidation.ModelStateErrors!
				);

		var isDefaultAvatar = user.AvatarAddress == PathTools.DefaultUserAvatar;

		var savingResult = new FileManagement().ReplaceFile(
			avatar,
			PathTools.AvatarServerPath,
			isDefaultAvatar ? "" : user.AvatarAddress);

		if (!savingResult.IsSuccess)
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				savingResult.ModelStateErrors!
				);
		user.AvatarAddress = savingResult.Data!;

		await _userRepository.UpdateAsync(user, true);

		return new OperationResult<bool>(true, true, PropertyDictionary.GnOperationSuccessfulltDone, StatusResultEnum.Success);
	}

	public async Task<OperationResult<UserPanelUserDataViewModel>> GetUserData(long userId)
	{
		var user = _userRepository.GetById(userId);
		if (user == null)
			return new OperationResult<UserPanelUserDataViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		var result = _mapper.Map<UserPanelUserDataViewModel>(user);
		result.Countries = (await _stateService.GetCuntries()).Data;
		if (user.CountryId != null)
		{
			result.Cities = (await _stateService.GetCities(user.CountryId)).Data;
		}

		return new OperationResult<UserPanelUserDataViewModel>(
			true,
			result,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<UserPanelTopHeaderViewModel>> GetUserDataTopHeader(long userId)
	{
		var user = _userRepository.GetById(userId);
		if (user == null)
			return new OperationResult<UserPanelTopHeaderViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		var result = new UserPanelTopHeaderViewModel()
		{
			CompanyName = user.Company,
			CountryTitle = _stateRepository.GetById(user.CountryId ?? 0L)?.Title ?? "",
			JobTitle = user.JobTitle,
			VisitCount = 0
		};
		return new OperationResult<UserPanelTopHeaderViewModel>(
			true,
			result,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success
			);
	}

	public async Task<OperationResult<UserPanelUserDataViewModel>> UpdateUserProfile(long userId, UserPanelUserDataViewModel profile)
	{
		profile.Countries = (await _stateService.GetCuntries()).Data;
		if (profile.CountryId != null)
		{
			profile.Cities = (await _stateService.GetCities(profile.CountryId)).Data;
		}

		var validation = await new ModelVerification().ModelValidation(profile);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
			return new OperationResult<UserPanelUserDataViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				validation.ModelStateErrors);

		var user = _userRepository.GetById(userId);

		if (user == null)
			return new OperationResult<UserPanelUserDataViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		// Check Country
		if (profile.CountryId != null && !_stateRepository.GetEntity(a => a.Id == profile.CountryId && a.ParentId == null).Any())
			return new OperationResult<UserPanelUserDataViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(
					nameof(profile.CityId),
					PropertyDictionary.CountryNotFound
					)
				);

		// Check City
		if (profile.CityId != null && !_stateRepository.GetEntity(a => a.Id == profile.CityId && a.ParentId == profile.CountryId).Any())
			return new OperationResult<UserPanelUserDataViewModel>(
				false,
				null!,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError(
					nameof(profile.CityId),
					PropertyDictionary.CityNotFound
					)
				);

		user.FirstName = profile.FirstName;
		user.LastName = profile.LastName;
		user.Company = profile.Company;
		user.JobTitle = profile.JobTitle;
		user.BirthDate = profile.BirthDate?.ToMildatiDate();
		user.CountryId = profile.CountryId;
		user.CityId = profile.CityId;
		user.AboutMe = profile.AboutMe;
		user.GetNewLetter = profile.GetNewsLetter;

		if (string.IsNullOrWhiteSpace(user.Email))
			user.Email = profile.Email;

		if (string.IsNullOrWhiteSpace(user.Mobile))
			user.Mobile = profile.Mobile;
		await _userRepository.UpdateAsync(user, true);
		return new OperationResult<UserPanelUserDataViewModel>(
			true,
			profile,
			PropertyDictionary.GnOperationSuccessfulltDone,
			StatusResultEnum.Success);
	}

	#endregion User Panel
}