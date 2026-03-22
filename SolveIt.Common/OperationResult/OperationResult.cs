namespace SolveIt.Common.OperationResult;
public class OperationResult<TEntity>
{
	#region Properties
	public bool IsSuccess { get; set; }
	public TEntity? Data { get; set; }
	public string? Message { get; set; }
	public List<ModelStateError>? ModelStateErrors { get; set; }
	public StatusResultEnum Status { get; set; }
	#endregion Properties

	#region Constructor
	public OperationResult(
		bool isSuccess,
		TEntity? data,
		string? message,
		StatusResultEnum status,
		List<ModelStateError> modelStateErrors) : base()
	{
		this.IsSuccess = isSuccess;
		this.Message = message;
		this.Data = data!;
		this.Status = status;
		this.ModelStateErrors = modelStateErrors;
	}

	public OperationResult(
		bool isSuccess,
		TEntity? data,
		string? message,
		StatusResultEnum status,
		ModelStateError? modelStateError = null) : base()
	{
		this.IsSuccess = isSuccess;
		this.Message = message;
		this.Data = data!;
		this.Status = status;
		this.ModelStateErrors = modelStateError == null ? null : new List<ModelStateError>
		{
			modelStateError
		};
	}
	#endregion Constructor
}

public class ModelStateError
{
	public string ModelStateField { get; set; }
	public string ModelStateErrorMessage { get; set; }

	#region Methods
	public static ModelStateError MakeModelStateError(string field, string message)
	{
		return new ModelStateError()
		{
			ModelStateField = field,
			ModelStateErrorMessage = message
		};
	}
	#endregion Methods
}

public enum StatusResultEnum
{
	Success = 0,
	ValidationError = 1,
	NotFound = 2,
	Retry = 3,
	AnyOtherError = 99

}
