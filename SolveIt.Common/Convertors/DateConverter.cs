using System.Globalization;
namespace SolveIt.Common.Converter;
public static class DateConverter
{
	public static string ToPersianDate(this DateTime value, string dateDelimeter = "/")
	{
		PersianCalendar pc = new();
		var persianDate =
			pc.GetYear(value) + dateDelimeter +
			pc.GetMonth(value).ToString("00") + dateDelimeter +
			pc.GetDayOfMonth(value).ToString("00");

		return persianDate;
	}

	public static string ToPersianDateWithTime(this DateTime value, string dateDelimeter = "/")
	{
		var persianDate = value.ToPersianDate();
		var time =
			value.Hour.ToString("00") + ":" +
			value.Minute.ToString("00");

		var longTime = persianDate + " - " + time;
		return longTime;
	}

	public static DateTime? ToMildatiDate(this string? value, char dateDelimeter = '/')
	{
		if (string.IsNullOrEmpty(value))
			return null;
		if (!value.IsPersianDateOrEmpty())
			return null;

		var gregorianDate = new DateTime();
		var persianCalendar = new PersianCalendar();
		var Gregoriancal = new GregorianCalendar();
		var dateParts = value.Split(dateDelimeter).ToArray();

		var year = dateParts[0];
		var month = dateParts[1];
		var day = dateParts[2];

		var date = persianCalendar.ToDateTime(int.Parse(year), int.Parse(month), int.Parse(day), 0, 0, 0, 0, 0);
		int MiladiYear = int.Parse(Gregoriancal.GetYear(date).ToString());
		int MiladiMonth = int.Parse(Gregoriancal.GetMonth(date).ToString());
		int MiladiDay = int.Parse(Gregoriancal.GetDayOfMonth(date).ToString());
		gregorianDate = DateTime.Parse(MiladiYear + "-" + MiladiMonth + "-" + MiladiDay).Date;
		return gregorianDate;

	}

	public static bool IsPersianDateOrEmpty(this string value, char dateDelimiter = '/')
	{
		if (string.IsNullOrWhiteSpace(value))
			return true;

		var dateParts = value.Split('/');

		if (dateParts.Length != 3)
			return false;

		if (!int.TryParse(dateParts[0], out var _) ||
		!int.TryParse(dateParts[1], out var _) ||
		!int.TryParse(dateParts[2], out var _))
			return false;

		var year = dateParts[0];
		var month = dateParts[1];
		var day = dateParts[2];

		if (year.ToString().Count() != 4 || year.Contains("_"))
			return false;

		if (month.ToString().Count() != 2 || month.Contains("_"))
			return false;

		if (int.Parse(month) > 12)
			return false;


		if (day.ToString().Count() != 2 || day.Contains("_"))
			return false;

		if (int.Parse(day) > 31)
			return false;

		try
		{
			var pc = new PersianCalendar();
			pc.ToDateTime(int.Parse(year), int.Parse(month), int.Parse(day), 0, 0, 0, 0);
			return true;
		}
		catch
		{
			return false;
		}
	}
}