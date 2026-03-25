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

		var gregorianDate = new DateTime();
		var persianCalendar = new PersianCalendar();
		var Gregoriancal = new GregorianCalendar();
		var dateParts = value.Split(dateDelimeter).ToArray();


	

		var year = dateParts[0];
		var month = dateParts[1];
		var day = dateParts[2];
		//if (!year.StartsWith("13") && !year.StartsWith("14"))
		//	return null;

		if (year.ToString().Count() != 4 || year.Contains("_"))
			return null;

		if (month.ToString().Count() != 2 || month.Contains("_"))
			return null;

		if (int.Parse(month) > 12)
			return null;


		if (day.ToString().Count() != 2 || day.Contains("_"))
			return null;

		if (int.Parse(day) > 31)
			return null;

		var date = persianCalendar.ToDateTime(int.Parse(year), int.Parse(month), int.Parse(day), 0, 0, 0, 0, 0);
		int MiladiYear = int.Parse(Gregoriancal.GetYear(date).ToString());
		int MiladiMonth = int.Parse(Gregoriancal.GetMonth(date).ToString());
		int MiladiDay = int.Parse(Gregoriancal.GetDayOfMonth(date).ToString());
		gregorianDate = DateTime.Parse(MiladiYear + "-" + MiladiMonth + "-" + MiladiDay).Date;
		return gregorianDate;

	}
}