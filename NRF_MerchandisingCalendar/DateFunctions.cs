using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchandisingCalendar
{
    public static partial class DateFunctions
    {
        public static DateTime? GetComparisonDay(DateTime _DateTime, Int32 _Year, Week53Options _Week53Options)
        {
            Int32 _Week = GetWeek(_DateTime);

            if (_Week == 53)
            {
                switch (_Week53Options)
                {
                    case Week53Options.AddWeek:

                        _Week = 1;

                        _Year = _Year + 1;

                        break;

                    case Week53Options.NonComp:

                        return null;

                    case Week53Options.SubtractWeek:

                        _Week = 52;

                        break;

                    default:

                        throw new ArgumentOutOfRangeException("_Week53Options");
                }
            }

            // Get list of dates for the same merch week from the inputted year.
            var weekRange = GetWeekDateRange(GetWeek(_DateTime), _Year).GetDatesInRange();

            // Return the date that falls on the same day of the week as the date.
            return weekRange.First(x => x.DayOfWeek == _DateTime.DayOfWeek);
        }

        public static Int32 GetDayOfYear(DateTime _Date)
        {
            int week = GetWeek(_Date);

            int dayOfWeek = ((int)_Date.DayOfWeek + 1);
            
            return (((week - 1) * 7) + dayOfWeek);
        }

        public static IEnumerable<MerchandisingDate> GetMerchandiseDatesByYear(Int32 _Year)
        {
            return GetYearDateRange(_Year).GetMerchandisingDatesInRange();
        }

        public static DateTime GetSalesReleaseDay(Int32 _Period, Int32 _Year)
        {
            //Retrieves the Sales Release Date of the period and year provided. Sales release day falls on the first Thursday of the period.
            return GetPeriodDateRange(_Period, _Year).StartDate.AddDays(4);
        }

        public static DateTime GetSalesReleaseDay(DateTime _Date)
        {
            var period = GetPeriod(_Date);
            var year = GetYear(_Date);

            return GetSalesReleaseDay(period, year);
        }

        public static IEnumerable<DateTime> GetSalesReleaseDatesForSeason(Season _Season, Int32 _Year)
        {
            // Set the starting period depending on the season.
            var startPeriod = _Season == Season.Spring ? 1 : 7;
            var returnValue = new List<DateTime>();

            /* Add sales release dates for all periods from the starting period to the end of the 
             * season (start period plus 5). */
            for (var i = startPeriod; i <= (startPeriod + 5); i++)
            {
                returnValue.Add(GetSalesReleaseDay(i, _Year));
            }

            return returnValue;
        }

        public static IEnumerable<DateTime> GetSalesReleaseDaysForYear(Int32 _Year)
        {
            var returnValue = new List<DateTime>();

            // Get sales release dates for priods 1 through 12.
            for (var i = 1; i <= 12; i++)
            {
                returnValue.Add(GetSalesReleaseDay(i, _Year));
            }

            return returnValue;
        }
    }
}