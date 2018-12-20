using System;

namespace MerchandisingCalendar
{
    /// <summary>
    /// Exception thrown for invalid values of the merchandise week.
    /// </summary>
    public class InvalidMerchWeekException : Exception
    {
        /// <summary>
        /// Exception thrown for invalid values of the merchandise week.
        /// </summary>
        /// <param name="week">
        /// The value that caused the exception.
        /// </param>
        public InvalidMerchWeekException(int week) :
            base("Merchandise week must be between 0 and 53. Week: " + week) { }
    }

    /// <summary>
    /// Exception thrown for invalid values of the merchandise period.
    /// </summary>
    public class InvalidPeriodException : Exception
    {
        /// <summary>
        /// Exception thrown for invalid values of the merchandise period.
        /// </summary>
        /// <param name="period">
        /// The value that caused the exception.
        /// </param>
        public InvalidPeriodException(int period) :
            base("Merchandise period must be between 1 and 12. Period: " + period) { }
    }

    /// <summary>
    /// Exception thrown for invalid values of the merchandise season.
    /// </summary>
    public class InvalidSeasonException : Exception
    {
        /// <summary>
        /// Exception thrown for invalid values of the merchandise season.
        /// </summary>
        /// <param name="season">
        /// The value that caused the exception.
        /// </param>
        public InvalidSeasonException(string season) :
            base("Merchandise season must be either Spring or Fall. Season: " + season) { }
    }

    /// <summary>
    /// Exception thrown for invalid values of the merchandise quarter.
    /// </summary>
    public class InvalidQuarterException : Exception
    {
        /// <summary>
        /// Exception thrown for invalid values of the merchandise quarter.
        /// </summary>
        /// <param name="quarter">
        /// The value that caused the exception.
        /// </param>
        public InvalidQuarterException(int quarter) :
            base("Quarter must be between 1 and 4. Quarter: " + quarter) { }
    }

    /// <summary>
    /// Exception thrown for date ranges where the start date is after the end date.
    /// </summary>
    public class InvalidDateRangeException : Exception
    {
        /// <summary>
        /// Exception thrown for date ranges where the start date is after the end date.
        /// </summary>
        /// <param name="dateRange">
        /// the DateRange that caused the exception.
        /// </param>
        public InvalidDateRangeException(DateRange dateRange) :
            base(String.Format("Start date must be before end date. Dates: {0} - {1}", dateRange.StartDate, dateRange.EndDate)) { }
    }
}
