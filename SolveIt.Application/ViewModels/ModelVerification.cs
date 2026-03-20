using System.ComponentModel.DataAnnotations;

namespace SolveIt.Application.ViewModels;
public class ModelVerification
{
	public async Task<OperationResult<bool, ValidationResultEnum>> ModelValidation(object model)
	{
		var validations = new List<ValidationResult>();
		var errors = new List<ModelStateError>();
		if (model == null)
			return new OperationResult<bool, ValidationResultEnum>(false, false, PropertyDictionary.GnSomethingWenWrong, ValidationResultEnum.Failed, ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		var context = new ValidationContext(model);
		var res = Validator.TryValidateObject(
			model,
			context,
			validations,
			validateAllProperties: true
		);
		if (res)
			return new OperationResult<bool, ValidationResultEnum>(true, true, "",ValidationResultEnum.Success);

		foreach (var item in validations)
		{
			foreach (var err in item.MemberNames)
			{
				errors.Add(ModelStateError.MakeModelStateError(err, item.ErrorMessage ?? ""));
			}
		}

		return new OperationResult<bool, ValidationResultEnum>(false, false, PropertyDictionary.GnSomethingWenWrong, ValidationResultEnum.Failed, errors);
	}
}

public enum ValidationResultEnum
{
	Success = 0,
	Failed =1
}