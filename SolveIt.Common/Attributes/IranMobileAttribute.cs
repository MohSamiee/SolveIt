using SolveIt.Common.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SolveIt.Common.Attributes;

public class IranMobileAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var mobile = value as string;

		if (string.IsNullOrEmpty(mobile))
			return ValidationResult.Success;

		var regex = new Regex(@"^09\d{9}$");

		if (!mobile.IsIranMobileNumber())
		{
			return new ValidationResult(
				PropertyDictionary.MobileFormatIsNotCorrect,
				[validationContext.MemberName]
			);
		}

		return ValidationResult.Success;
	}
}
