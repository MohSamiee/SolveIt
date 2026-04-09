using Microsoft.AspNetCore.Http;

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
	Task<OperationResult<EmailForgotPasswordResponseViewModel>> ValidateForgotPasswordEmail(string emailCode);
	Task<OperationResult<ResetPasswordViewModel>> ResetPasswordGetData(string emailOrMobile, bool isForgotPassword);
	Task<OperationResult<bool>> ResetPassword(ResetPasswordViewModel reset);


	Task<OperationResult<UserPanelSidebarViewModel>> GetUserForSidebarPanel(long userId);
	Task<OperationResult<bool>> ChangeUserAvatar(long userId, IFormFile avatar);
	Task<OperationResult<UserPanelUserDataViewModel>> GetUserData(long userId);
	Task<OperationResult<UserPanelTopHeaderViewModel>> GetUserDataTopHeader(long userId);
	Task<OperationResult<UserPanelUserDataViewModel>> UpdateUserProfile(long userId, UserPanelUserDataViewModel profile);
	Task<OperationResult<bool>> ChangePassword(long userId, ChangePassword change);

}
