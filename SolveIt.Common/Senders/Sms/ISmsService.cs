namespace SolveIt.Common.Senders.Sms;
public interface ISmsService
{
	Task<SendSmsStatus> SendNowToOnePersonSms(SmsSetting setting, string messageText, string mobileNumber);
}
