namespace SolveIt.Application.Services.Interfaces.Accounts;
public interface IUserService
{
	Task<OperationResult<User>> RegisterUser(RegisterViewModel register);
	Task<OperationResult<User>> ValidateLogin(LoginViewModel login);
	Task<OperationResult<User>> ActivateEmail(string activationCode);
	Task<OperationResult<User>> ActivateMobile(RegisterMobileVerficationViewModel activation);
	Task<OperationResult<User>> ReSendMobileActivationCode(string mobile);
}
