using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SolveIt.Common.Attributes;

public class PersianDateAttribute : ValidationAttribute, IClientModelValidator
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
	public void AddValidation(ClientModelValidationContext context)
	{
		MergeAttribute(context.Attributes, "data-val", "true");
		MergeAttribute(context.Attributes, "data-val-persianDate", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
	}

	private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
	{
		if (attributes.ContainsKey(key))
			return false;

		attributes.Add(key, value);
		return true;
	}
}
