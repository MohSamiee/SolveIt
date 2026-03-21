using Microsoft.AspNetCore.Http;

namespace SolveIt.Common.Utilities;
public class FileManagement
{
	/// <summary>
	/// Return File Name
	/// </summary>
	/// <param name="file"></param>
	/// <param name="path"></param>
	/// <param name="fileName"></param>
	/// <returns></returns>
	public OperationResult<string> SaveFile(IFormFile file, string path, string fileName = "")
	{
		var myFileName = string.Empty;
		if (file == null)
			return new OperationResult<string>(false, string.Empty, string.Empty, StatusResultEnum.AnyOtherError, ModelStateError.MakeModelStateError("", PropertyDictionary.FileIsEmpty));

		if (string.IsNullOrWhiteSpace(fileName))
			myFileName = CodeGenerator.GenerateRandomFileName() + Path.GetExtension(file.FileName);
		else
			myFileName = fileName;

		var fullPath = Path.Combine(path, myFileName);
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);

		using (var stream = File.Create(fullPath))
		{
			file.CopyTo(stream);
		}

		return new OperationResult<string>(true, myFileName, string.Empty, StatusResultEnum.Success);
	}

	public OperationResult<string> ReplaceFile(IFormFile file, string path, string oldFileName, string fileName = "")
	{
		var newFileName = SaveFile(file, path, fileName);

		if (string.IsNullOrWhiteSpace(oldFileName))
			return newFileName;


		var deleteStatus = DeleteFile(path, oldFileName);

		if (newFileName.IsSuccess && deleteStatus.IsSuccess)
			return newFileName;

		var errors = (newFileName.ModelStateErrors ?? new List<ModelStateError>()).Union((deleteStatus.ModelStateErrors) ?? new List<ModelStateError>()).ToList();
		return new OperationResult<string>(false, string.Empty, string.Empty, StatusResultEnum.AnyOtherError, errors);
	}

	public OperationResult<bool> DeleteFile(string path, string fileName)
	{
		var fullPath = Path.Combine(path, fileName);
		if (File.Exists(fullPath))
		{
			File.Delete(fullPath);
		}
		return new OperationResult<bool>(true, true, string.Empty, StatusResultEnum.Success);
	}

	public static string GetProjectRootPath()
	{
		return Directory.GetCurrentDirectory();
	}
}
