using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace SolveIt.Web.Extensions.Register;

public static class RegisterEncoder
{
	public static void RegisterHtmlEncoder(this WebApplicationBuilder builder)
	{
		builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[]
		{
			UnicodeRanges.BasicLatin,
			UnicodeRanges.Arabic
		}));
	}
}
