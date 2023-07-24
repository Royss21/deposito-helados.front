
namespace DepositoHelados.Domain.Commons.Functions;

public static class DateTimeExtension
{

      public static DateTime GetDatePeru(this DateTime currentDate)
        {
            DateTime currentDatePeru = TimeZoneInfo.ConvertTime(currentDate, GetHourZonePeru());
            return currentDatePeru.Date;
        }

        public static DateTime GetDateTimePeru(this DateTime currentDate)
        {
            DateTime currentDatePeru = TimeZoneInfo.ConvertTime(currentDate, GetHourZonePeru());
            return currentDatePeru;
        }

        public static TimeZoneInfo GetHourZonePeru()
        {
            string displayName = "(GMT-05:00) Peru Time";
            string standardName = "Peru Time";
            TimeSpan offset = new TimeSpan(-5, 0, 0);
            return TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
        }

        public static int TimeToNumeric(this DateTime? fecha) => int.Parse((fecha?.ToString("hh:mm:ss") ?? "0").Replace(":", ""));
        public static int DateTimeToNumeric(this DateTime? fecha) => int.Parse((fecha?.ToString("yyyy/MM/dd hh:mm:ss") ?? "0").Replace(":", "").Replace("/", "").Replace(" ", ""));
        public static int DateToNumeric(this DateTime? fecha) => int.Parse((fecha?.ToString("yyyy/MM/dd") ?? "0").Replace("/", ""));

}