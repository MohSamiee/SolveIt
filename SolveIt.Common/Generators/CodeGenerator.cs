namespace BestShop.Common.Generator;
public static class CodeGenerator
{
	public static string GenerateActivationEmailCode()
	{
		var res = Guid.NewGuid().ToString("N");
		return res;
	}
}
