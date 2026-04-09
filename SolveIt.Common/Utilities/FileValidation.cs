using Microsoft.AspNetCore.Http;

namespace SolveIt.Common.Utilities;
public class FileValidation
{
	#region Avatar
	public OperationResult<bool> IsValidFile(IFormFile image, FileSetting fileSetting, bool isImage)
	{
		var extensionValidation = CheckFileExtension(image, fileSetting);
		if (!extensionValidation.IsSuccess)
			return extensionValidation;

		var fileSizeValidation = CheckFileSize(image, fileSetting);
		if (!fileSizeValidation.IsSuccess)
			return fileSizeValidation;

		var fileContentTypeValidation = CheckFileContentType(image, fileSetting);
		if (!fileContentTypeValidation.IsSuccess)
			return fileContentTypeValidation;

		if (isImage)
		{
			var deepCheck = ValidateImage(image);
			if (!deepCheck.IsSuccess)
				return deepCheck;
		}

		return new OperationResult<bool>(true, true, string.Empty, StatusResultEnum.Success);
	}
	#endregion Avatar

	#region Privates
	private OperationResult<bool> CheckFileExtension(IFormFile file, FileSetting fileSetting)
	{
		var extension = Path.GetExtension(file.FileName).ToLower();

		if (!fileSetting.AcceptableExtensions.Contains(extension))
		{
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				new List<ModelStateError>()
			{
				new(){ModelStateField="",ModelStateErrorMessage = PropertyDictionary.FileFormatAllowedAsBelow},
				new (){ModelStateField = "",ModelStateErrorMessage = string.Join(",",fileSetting.AcceptableExtensions)}
			});
		}
		return new OperationResult<bool>(true, true, string.Empty, StatusResultEnum.Success);
	}

	private OperationResult<bool> CheckFileSize(IFormFile file, FileSetting fileSetting)
	{
		if (file.Length == 0)
			return new OperationResult<bool>(
				false,
				false,
				string.Empty,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError(
				"", string.Format(PropertyDictionary.GnRequiredErrorMessage, PropertyDictionary.Avatar
				)));

		var extension = Path.GetExtension(file.FileName).ToLower();

		if (file.Length > fileSetting.MaxFileSize)
		{
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				ModelStateError.MakeModelStateError
				("", string.Format(PropertyDictionary.GnFileSizeError, fileSetting.MaxFileSizeMb + " Mb")));
		}
		return new OperationResult<bool>(true, true, string.Empty, StatusResultEnum.Success);
	}

	private OperationResult<bool> CheckFileContentType(IFormFile file, FileSetting fileSetting)
	{
		var contentType = file.ContentType.ToLower();

		if (!fileSetting.AcceptableContentType.Contains(file.ContentType.ToLower()))
		{
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				new List<ModelStateError>()
				{
					new(){ModelStateField="",ModelStateErrorMessage = PropertyDictionary.FileFormatAllowedAsBelow},
					new (){ModelStateField = "",ModelStateErrorMessage = string.Join(",",fileSetting.AcceptableExtensions)}
				});
		}
		return new OperationResult<bool>(true, true, string.Empty, StatusResultEnum.Success);

	}

	private OperationResult<bool> ValidateImage(IFormFile file)
	{
		try
		{
			using var stream = file.OpenReadStream();
			Span<byte> header = stackalloc byte[8];
			stream.ReadExactly(header);

			var isJpeg = header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
			var isPng = header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47;

			if (isJpeg || isPng)
				return new OperationResult<bool>(true, true, string.Empty, StatusResultEnum.Success);


			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				new List<ModelStateError>()
				{
					new(){ModelStateField="",ModelStateErrorMessage = PropertyDictionary.FileFormatAllowedAsBelow}
				});
		}
		catch
		{
			return new OperationResult<bool>(
				false,
				false,
				PropertyDictionary.GnSomethingWenWrong,
				StatusResultEnum.AnyOtherError,
				new List<ModelStateError>()
				{
					new(){ModelStateField="",ModelStateErrorMessage = PropertyDictionary.FileFormatAllowedAsBelow}
				});
		}
	}
	#endregion Privates
}