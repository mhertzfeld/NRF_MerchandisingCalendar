using System;

namespace MerchandisingCalendar
{
    public static partial class DateFunctions
    {
        public static Int32 GetPeriod(DateTime _Date)
        {
            return GetPeriod(GetWeek(_Date));
        }

        public static Int32 GetPeriod(Int32 _Week)
        {
            // Make sure the week is valid.
            if (_Week < 0 || _Week > 53)
            { throw new InvalidMerchWeekException(_Week); }

            // Returns period based on 4-5-4 quarter structure.
            if (_Week <= 4)
                return 1;

            if (_Week <= 9)
                return 2;

            if (_Week <= 13)
                return 3;

            if (_Week <= 17)
                return 4;

            if (_Week <= 22)
                return 5;

            if (_Week <= 26)
                return 6;

            if (_Week <= 30)
                return 7;

            if (_Week <= 35)
                return 8;

            if (_Week <= 39)
                return 9;

            if (_Week <= 43)
                return 10;

            return _Week <= 48 ? 11 : 12;
        }

        public static DateRange GetPeriodDateRange(int _Period, Int32 _Year)
        {
            // Make sure it's a valid period.
            ValidatePeriod(_Period);

            // Get merchandise year information.
            var merchYear = GetYearDateRange(_Year);
            // Number of weeks' worth of days to skip to get to the beginning of the period.
            var weeksToSkip = 0;

            // Add the number of weeks in each period up to the period passed in to get the number of weeks to skip.
            for (var i = 1; i < _Period; i++)
            {
                weeksToSkip += GetWeeksInPeriod(i, _Year);
            }

            var merchYearStartDate = merchYear.StartDate;
            var weeksInPeriod = GetWeeksInPeriod(_Period, _Year);

            /* Add the number of days in the weeks to skip variable to the merch year start date to get
             * the start date of the date range. */
            var startDate = merchYearStartDate.AddDays(weeksToSkip * 7);
            // add the number of days in the period to the start date to get the end date.
            var endDate = startDate.AddDays((weeksInPeriod * 7) - 1).SetToEndOfDay();

            return new DateRange(startDate, endDate);
        }

        public static DateRange GetPeriodDateRange(DateTime _Date, Boolean _ToDate = false)
        {
            var period = GetPeriod(_Date);
            var year = GetYear(_Date);

            DateRange _DateRange = GetPeriodDateRange(period, year);

            if (_ToDate)
            { return new DateRange(_DateRange.StartDate, _Date); }
            else
            { return _DateRange; }
        }

        public static String GetPeriodName(Int32 _Period)
        {
            int _Month = (_Period + 1);

            if (_Month == 13)
            { _Month = 1; }

            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_Month);
        }

        public static Int32 GetWeeksInPeriod(Int32 _Period, Int32 _Year)
        {
            /* Merchandise calendar quarters are based on a 4-5-4 week pattern, repeated 4 times to make up the year.
             * 5 week periods are 2, 5, 8 and 11, all others have 4 weeks. */
            if ((GetWeeksInYear(_Year) == 53) && (_Period == 1))
            { return 5; }
            else
            {
                if (_Period == 2 ||
                    _Period == 5 ||
                    _Period == 8 ||
                    _Period == 11)
                    return 5;

                return 4;
            }
        }

        public static void ValidatePeriod(Int32 _Period)
        {
            if (_Period < 1 || _Period > 12)
                throw new InvalidPeriodException(_Period);
        }
    }
}
