namespace SolveIt.Application.Services.Interfaces.Accounts;
public interface IUserService
{
	Task<OperationResult<User>> RegisterUser(RegisterViewModel register);
	Task<OperationResult<User>> ValidateLogin(LoginViewModel login);
	Task<OperationResult<User>> ActivateEmail(string activationCode);
	Task<OperationResult<RegisterMobileVerficationViewModel>> ActivateMobile(RegisterMobileVerficationViewModel activation);
	Task<OperationResult<User>> ReSendMobileActivationCode(string mobile);
	Task<OperationResult<ForgotPasswordResponseViewModel>> ForgotPassword(ForgotPasswordViewModel forgot);
	Task<OperationResult<MobileForgotPasswordResponseViewModel>> ValidateForgotPasswordMobile(MobileForgotPasswordResponseViewModel validation);
	Task<OperationResult<User>> ValidateForgotPasswordEmail(String emailCode);
}
