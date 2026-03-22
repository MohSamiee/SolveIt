
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SolveIt.Common.Utilities;
public static class MyValidator
{
	public static bool IsEmailAddress(this string email)
	{
		try
		{
			var emailAddress = new MailAddress(email);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsIranMobileNumber(this string mobile)
	{
		return Regex.IsMatch(mobile, @"^09\d{9}$");
	}
}
