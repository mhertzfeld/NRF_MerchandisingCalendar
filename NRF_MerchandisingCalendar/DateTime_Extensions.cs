using System;

namespace MerchandisingCalendar
{
    public static class DateTime_Extensions
    {
        public static DateTime SetToEndOfDay(this DateTime date)
        {
            // Sets time to the end of the day. Useful for reporting based on date ranges.
            return date.Date
                .AddHours(23)
                .AddMinutes(59)
                .AddSeconds(59)
                .AddMilliseconds(999);
        }
    }
}