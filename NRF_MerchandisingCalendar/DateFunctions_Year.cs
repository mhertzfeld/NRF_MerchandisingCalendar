using System;

namespace MerchandisingCalendar
{
    public static partial class DateFunctions
    {
        public static Int32 GetWeeksInYear(Int32 _Year)
        {
            DateRange _Year_DateRange = GetYearDateRange(_Year);

            return (((Int32)(_Year_DateRange.EndDate - _Year_DateRange.StartDate).TotalDays + 1) / 7);
        }

        public static Int32 GetYear(DateTime date)
        {
            var year = date.Year;
            var merchYear = GetYearDateRange(year);

            // if the date is not in the date range for the merchandise year it is part of the previous year.
            if (date >= merchYear.StartDate && date <= merchYear.EndDate)
                return year;

            return year - 1;
        }

        public static DateRange GetYearDateRange(Int32 _Year)
        {
            // Merchandise calendar starts in February.
            var firstDayOfFeb = new DateTime(_Year, 2, 1);

            // Integer representing the day of the week for the first of February.
            var firstFebDayOfWeek = (int)firstDayOfFeb.DayOfWeek;
            var nextYear = _Year + 1;

            /* Subtract days until you get to Sunday, which is the start of a merchandise calendar week.
             * This is your start date for the year, except when... */
            var startDate = firstDayOfFeb.AddDays((0 - firstFebDayOfWeek));

            /* ...February 1st falls on Thu - Sat, meaning there are more than three days from January in the
             * first week, also meaning the year before was a 53 week year. In that case, add a week 
             * to the start date. */
            if (firstFebDayOfWeek > 3)
                startDate = startDate.AddDays(7);

            /* Add 52 weeks' worth of days (364) to the start date to get the end date, taking into 
             * account the start day constitutes one of them (-1). */
            var endDate = startDate.AddDays(363);

            /* If the end date is January 27th of next year or earlier, there will be more than 3 January
             * days at the beginning of the next year and another week needs to be added to account for this. */
            if (endDate <= new DateTime(nextYear, 1, 27))
            {
                endDate = endDate.AddDays(7);
            }

            return new DateRange(startDate, endDate.SetToEndOfDay());
        }

        public static DateRange GetYearDateRange(DateTime date, Boolean _ToDate)
        {
            var year = GetYear(date);
            DateRange _DateRange = GetYearDateRange(year);

            if (_ToDate)
            { return new DateRange(_DateRange.StartDate, date); }
            else
            { return _DateRange; }
        } 
    }
}
