using System;

namespace Meta.IntroApp.Helpers
{
    public static class DateTimeHelper
    {
        public static string GetTime(this DateTime date)
        {
            return date.ToString("hh:mm");
        }

        public static string GetTime(this DateTime? date)
        {
            return date?.ToString("hh:mm tt") ?? string.Empty;
        }

        public static string GetDate(this DateTime date)
        {
            return date.ToString("yyyy-MMM-ddd");
        }

        public static string GetDate(this DateTime? date)
        {
            return date?.ToString("yyyy-MMM-dd hh-mm-ss") ?? string.Empty;
        }
    }
}