using System.Globalization;

namespace Infrastructure.Tools.Extensions;

public static class DateTimeExtensions
{
    public static string ToPersianDate(this DateTime date, string separator = "/")
    {
        PersianCalendar pc = new PersianCalendar();
        return $"{pc.GetYear(date)}{separator}{pc.GetMonth(date).ToString("D2")}{separator}{pc.GetDayOfMonth(date).ToString("D2")}";
    }
    public static string RawDateToFormattedDate(string rawDate, string seperator = "/")
    {
        if (string.IsNullOrEmpty(rawDate) || rawDate.Length != 8)
        {
            return rawDate;
        }

        return $"{rawDate[0..4]}{seperator}{rawDate[4..6].PadLeft(2,'0')}{seperator}{rawDate[6..8].PadLeft(2, '0')}";
    }
    public static DateTime ToMiladiDateTime(string persianDate, string? separator)
    {
        PersianCalendar persianCalendar = new();
        if (string.IsNullOrEmpty(separator))
            return new DateTime(int.Parse(persianDate[0..4]), int.Parse(persianDate[4..6]), int.Parse(persianDate[6..8]), persianCalendar);
        string[] parts = persianDate.Split(separator);

        return new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), persianCalendar);
    }
}
