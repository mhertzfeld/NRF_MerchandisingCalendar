//using System;

//namespace MerchandisingCalendar
//{
//    public static partial class DateFunctions
//    {
//        public static string GetSeason(DateTime date)
//        {
//            return GetSeason(GetWeek(date));
//        }

//        public static string GetSeason(int week)
//        {
//            // Make sure the week is valid.
//            ValidateWeek(week);

//            return week <= 26 ? "Spring" : "Fall";
//        }

//        public static DateRange GetSeasonDateRange(Season season, int year)
//        {
//            // Default to Spring season, weeks 1 through 26.
//            var startWeek = 1;
//            var endWeek = 26;

//            if (season == Season.Fall)
//            {
//                startWeek = 27;

//                endWeek = GetWeeksInYear(year);
//            }

//            var startDate = GetWeekDateRange(startWeek, year).StartDate;
//            var endDate = GetWeekDateRange(endWeek, year).EndDate.SetToEndOfDay();

//            return new DateRange(startDate, endDate);
//        }

//        public static DateRange GetSeasonDateRange(DateTime date)
//        {
//            // Get the season for the date passed in.
//            Season season;
//            var seasonString = GetSeason(date);
//            var seasonParsed = Enum.TryParse(seasonString, out season);

//            // Check if it's a valid season.
//            if (!seasonParsed)
//                throw new InvalidSeasonException(seasonString);

//            var year = GetYear(date);

//            return GetSeasonDateRange(season, year);
//        }
//    }
//}