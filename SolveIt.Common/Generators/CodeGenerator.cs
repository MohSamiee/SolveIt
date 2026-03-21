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
}
