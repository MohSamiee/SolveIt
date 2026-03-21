namespace SolveIt.Common.Converter;
public class MyPersianDate
{
	public DateTime MiladiDate { get; set; }

	public string PersianDate { get; set; }
	public int PersianYear { get; set; }
	public int PersianMonth { get; set; }
	public string PersianMonthString { get; set; }
	public string PersianMonthName { get; set; }
	public int PersianDayOfMonth { get; set; }
	public string PersianDayOfMonthString { get; set; }

	public static Dictionary<int, string> PersianMonthNames = new()
	{
		{1,"فروردین" },
		{2,"اردیبهشت" },
		{3,"خرداد" },
		{4,"تیر" },
		{5,"مرداد" },
		{6,"شهریور" },
		{7,"مهر" },
		{8,"آبان" },
		{9,"آذر" },
		{10,"دی" },
		{11,"بهمن" },
		{12,"اسفند" },
	};

	public MyPersianDate? GetDateElement(DateTime? date)
	{
		if (date == null)
			return null!;


		var persian = date.Value.ToPersianDate("/");
		var res = new MyPersianDate()
		{
			MiladiDate = date.Value,
			PersianDate = persian,
			PersianYear = int.Parse(persian.Split("/")[0]),
			PersianMonth = int.Parse(persian.Split("/")[1]),
			PersianMonthString = persian.Split("/")[1],
			PersianDayOfMonth = int.Parse(persian.Split("/")[2]),
			PersianDayOfMonthString = persian.Split("/")[2]
		};
		if (PersianMonthNames.TryGetValue(res.PersianMonth, out var monthName))
		{
			res.PersianMonthName = monthName;
		}
		return res;
	}

	public MyPersianDate? GetDateElement(string? persianDate)
	{
		var miladiDate = persianDate.ToMildatiDate('/');
		return GetDateElement(miladiDate);
	}
}
