using System;

namespace MerchandisingCalendar
{
    public static partial class DateFunctions
    {
        public static Int32 GetQuarter(DateTime _Date)
        {
            var period = GetPeriod(_Date);
            var year = GetYear(_Date);

            return GetQuarter(period, year);
        }

        public static Int32 GetQuarter(Int32 period, Int32 _Year)
        {
            return (int)Math.Ceiling((decimal)period / 3);
        }

        public static String GetQuarterName(Int32 _Quarter)
        {
            switch (_Quarter)
            {
                case 1:

                    return "Spring";

                case 2:

                    return "Summer";

                case 3:

                    return "Fall";

                case 4:

                    return "Winter";

                default:

                    throw new Exception("Invalid Quarter.");
            }
        }

        public static DateRange GetQuarterDateRange(DateTime _DateTime, Boolean _ToDate = false)
        {
            Int32 _Quarter = GetQuarter(_DateTime);

            Int32 _Year = GetYear(_DateTime);

            DateRange _DateRange = GetQuarterDateRange(_Quarter, _Year);

            if (_ToDate)
            { return new DateRange(_DateRange.StartDate, _DateTime); }
            else
            { return _DateRange; }
        }

        public static DateRange GetQuarterDateRange(Int32 _Quarter, Int32 _Year)
        {
            Int32 _EndPeriod;
            Int32 _StartPeriod;
            switch (_Quarter)
            {
                case 1:

                    _EndPeriod = 3;
                    _StartPeriod = 1;

                    break;

                case 2:

                    _EndPeriod = 6;
                    _StartPeriod = 4;

                    break;

                case 3:

                    _EndPeriod = 9;
                    _StartPeriod = 7;

                    break;

                case 4:

                    _EndPeriod = 12;
                    _StartPeriod = 10;

                    break;

                default:

                    throw new InvalidQuarterException(_Quarter);
            }

            DateTime _EndDate = GetPeriodDateRange(_EndPeriod, _Year).EndDate;

            DateTime _StartDate = GetPeriodDateRange(_StartPeriod, _Year).StartDate;

            return new DateRange(_StartDate, _EndDate);
        }

        public static void ValidateQuarter(Int32 _Quarter)
        {
            if (_Quarter < 1 || _Quarter > 5)
                throw new InvalidQuarterException(_Quarter);
        }
    }
}
