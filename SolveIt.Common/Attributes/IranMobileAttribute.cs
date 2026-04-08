using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace SolveIt.Common.Attributes;
public class IranMobileAttribute : ValidationAttribute, IClientModelValidator
{
	public IranMobileAttribute()
	{
		ErrorMessageResourceType = typeof(PropertyDictionary);
		ErrorMessageResourceName = "MobileFormatIsNotCorrect";
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var mobile = value as string;

		if (string.IsNullOrWhiteSpace(mobile))
			return ValidationResult.Success;

		if (!mobile.IsIranMobileNumber())
		{
			return new ValidationResult(
				FormatErrorMessage(validationContext.DisplayName),
				new[] { validationContext.MemberName! }
			);
		}

		return ValidationResult.Success;
	}

	public void AddValidation(ClientModelValidationContext context)
	{
		MergeAttribute(context.Attributes, "data-val", "true");
		MergeAttribute(context.Attributes, "data-val-iranmobile", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
	}

	private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
	{
		if (attributes.ContainsKey(key))
			return false;

		attributes.Add(key, value);
		return true;
	}
}