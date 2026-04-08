using System.ComponentModel.DataAnnotations;

public class IranMobileAttribute : ValidationAttribute
{
	public IranMobileAttribute()
	{
		ErrorMessageResourceType = typeof(PropertyDictionary);
		ErrorMessageResourceName = "MobileFormatIsNotCorrect";
	}
	 
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var mobile = value as string;

		if (string.IsNullOrEmpty(mobile))
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
}
