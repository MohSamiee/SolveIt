using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels;
public class ModelVerification
{
	public async Task<OperationResult<bool>> ModelValidation(object model)
	{
		var validations = new List<ValidationResult>();
		var errors = new List<ModelStateError>();
		if (model == null)
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.ValidationError,
				ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		var context = new ValidationContext(model);
		var res = Validator.TryValidateObject(
			model,
			context,
			validations,
			validateAllProperties: true
		);
		if (res)
			return new OperationResult<bool>(true, true, "", StatusResultEnum.Success);

		foreach (var item in validations)
		{
			foreach (var err in item.MemberNames)
			{
				errors.Add(ModelStateError.MakeModelStateError(err, item.ErrorMessage ?? ""));
			}
		}

		return new OperationResult<bool>(
			false,
			false,
			PropertyDictionary.GnSomethingWenWrong,
			StatusResultEnum.ValidationError,
			errors);
	}
}