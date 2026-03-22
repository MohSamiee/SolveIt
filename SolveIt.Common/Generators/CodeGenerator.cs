using System.Security.Cryptography;

namespace SolveIt.Common.Generator;
public static class CodeGenerator
{
	public static string GenerateActivationEmailCode()
	{
		var res = Guid.NewGuid().ToString("N");
		return res;
	}

	public static string GenerateRandomFileName()
	{
		var res = Guid.NewGuid().ToString("N");
		return res;
	}
	public static string GenerateMobileCode(int length = 6)
	{
		const string firstChars = "123456789";
		const string chars = "0123456789";

		var codeChars = new char[length];

		using var rng = RandomNumberGenerator.Create();
		var randomBytes = new byte[length];

		rng.GetBytes(randomBytes);

		for (int i = 0; i < length; i++)
		{
			if (i == 0)
				codeChars[i] = chars[randomBytes[i] % firstChars.Length];
			else
				codeChars[i] = chars[randomBytes[i] % chars.Length];
		}

		return new string(codeChars);
	}
}
