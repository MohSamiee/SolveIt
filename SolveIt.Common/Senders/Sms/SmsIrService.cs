using IPE.SmsIrClient;

namespace SolveIt.Common.Senders.Sms;
public class SmsIrService: ISmsService
{
	public async Task<SendSmsStatus> SendNowToOnePersonSms(SmsSetting setting, string messageText, string mobileNumber)
	{
		var smsIr = new SmsIr(setting.ApiKey);
		var bulkSendResult = await smsIr.BulkSendAsync(setting.LineNumber, messageText, new string[] { mobileNumber });
		if (bulkSendResult.Status == 1)
		{
			return SendSmsStatus.Success;
		}
		return SendSmsStatus.Failed;
	}
}