using System;
using System.Linq;

namespace MerchandisingCalendar
{
    public static partial class DateFunctions
    {
        public static Int32 GetWeek(DateTime _Date)
        {
            // Get information about the merchandise year.
            var merchYear = GetYearDateRange(GetYear(_Date));
            // TimeSpan used to calculate the number of weeks from the beginning of the year to the date.
            var timeSpan = _Date - merchYear.StartDate;
            // Gets the number of days + 1 divided by 7, rounded up to the nearest whole number.
            var returnValue = (int)(Math.Ceiling((decimal)(timeSpan.Days + 1) / 7));
            
            return returnValue;
        }

        public static DateRange GetWeekDateRange(Int32 _Week, Int32 _Year)
        {
            // Make sure it's a valid week.
            ValidateWeek(_Week, _Year);

            // Get information about the merchandise year.
            var merchYear = GetYearDateRange(_Year);

            // Calculate values for the start and end dates.
            var startDate = merchYear.StartDate.AddDays(7 * (_Week - 1));
            var endDate = merchYear.StartDate.AddDays((7 * _Week) - 1).SetToEndOfDay();

            return new DateRange(startDate, endDate);
        }

        public static DateRange GetWeekDateRange(DateTime _Date, Boolean _ToDate)
        {
            DateRange _DateRange = GetWeekDateRange(GetWeek(_Date), GetYear(_Date));

            if (_ToDate)
            { return new DateRange(_DateRange.StartDate, _Date); }
            else
            { return _DateRange; }
        }

        public static DateRange GetWeekDateRange(Int32 _Week, Int32 _Year, DayOfWeek _DayOfWeek)
        {
            // Get a list of all dates between the date range for the week based on week number and year.
            var weekRange = GetWeekDateRange(_Week, _Year).GetDatesInRange();
            // Get the first date in the list that matches the day of the week.
            var date = weekRange.First(x => x.DayOfWeek == _DayOfWeek);

            return GetWeekDateRange(date, true);
        }

        public static void ValidateWeek(Int32 _Week, Int32 _Year)
        {
            if (GetWeeksInYear(_Year) == 53)
            {
                if (_Week < 0 || _Week > 53)
                    throw new InvalidMerchWeekException(_Week);
            }
            else
            {
                if (_Week < 0 || _Week > 52)
                    throw new InvalidMerchWeekException(_Week);
            }
        }
    }
}
