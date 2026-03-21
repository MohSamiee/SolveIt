namespace SolveIt.Application.Services.Interfaces.Accounts;
public interface  IUserService
{
	Task<OperationResult<RegisterViewModel>> RegisterUser(RegisterViewModel register);
	Task<OperationResult<User >> ValidateLogin(LoginViewModel login);
}
