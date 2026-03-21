
using SolveIt.Application.ViewModels.Accounts;
using SolveIt.Common.OperationResult;
using SolveIt.Entities.Models.Users;

namespace SolveIt.Application.Services.Interfaces.Accounts;
public interface  IUserService
{
	Task<OperationResult<RegisterViewModel>> RegisterUser(RegisterViewModel register);
}

#region Enums
public enum RegisterResult
{
	Success = 0,
	ModelValidation = 1,
	DuplicateEmail = 2
}
#endregion Enums
