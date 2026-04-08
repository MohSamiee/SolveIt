using System.ComponentModel.DataAnnotations;

namespace SolveIt.Common.Attributes;

public class PersianDateAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var persianDate = value as string;

		if (string.IsNullOrEmpty(persianDate))
			return ValidationResult.Success;

		if (!persianDate.IsPersianDateOrEmpty())
			return new ValidationResult(
						PropertyDictionary.PersianDateIsNotInFormat,
						[validationContext.MemberName]
					);
		try
		{
			var miladiDate = persianDate.ToMildatiDate();
			return ValidationResult.Success;

		}
		catch
		{
			return new ValidationResult(
				PropertyDictionary.PersianDateIsNotInFormat,
				[validationContext.MemberName]);
		}
	}
}
