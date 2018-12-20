using System;

namespace MerchandisingCalendar
{
    public class MerchandisingDate
    {
        #region FIELDS
        protected DateTime date;

        protected Int32 dayOfYear;

        protected Int32 period;

        protected Int32 quarter;
        
        protected Int32 week;

        protected Int32 year;
        #endregion

        #region PROPERTIES
        public virtual DateTime Date
        {
            get { return date; }

            protected set { date = value; }
        }

        public virtual Int32 DayOfYear
        {
            get { return dayOfYear; }

            protected set { dayOfYear = value; }
        }

        public virtual Int32 Period
        {
            get { return period; }

            protected set { period = value; }
        }

        public virtual String PeriodName
        {
            get { return DateFunctions.GetPeriodName(Period); }
        }

        public virtual Int32 Quarter
        {
            get { return quarter; }

            protected set { quarter = value; }
        }

        public virtual String QuarterName
        {
            get { return DateFunctions.GetQuarterName(Quarter); }
        }

        public virtual Int32 Week
        {
            get { return week; }

            protected set { week = value; }
        }

        public virtual Int32 Year
        {
            get { return year; }

            protected set { year = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public MerchandisingDate(DateTime Date)
        {
            this.Date = Date;

            DayOfYear = DateFunctions.GetDayOfYear(Date);

            Period = DateFunctions.GetPeriod(Date);

            Quarter = DateFunctions.GetQuarter(Date);

            Week = DateFunctions.GetWeek(Date);

            Year = DateFunctions.GetYear(Date);
        }

        public MerchandisingDate(DateTime Date, Int32 Year, Int32 Quarter, Int32 Period, Int32 Week, Int32 DayOfYear)
        {
            if (DateFunctions.GetWeeksInYear(Year) == 52)
            {
                if ((DayOfYear < 1) || (DayOfYear > 364))
                { throw new Exception("DayOfYear cannot be less than 1 or greater than 364."); }
            }
            else
            {
                if ((DayOfYear < 1) || (DayOfYear > 371))  //CHANGE THIS TO BE AWARE OF WEEK 52 and 53
                { throw new Exception("DayOfYear cannot be less than 1 or greater than 371."); }
            }

            DateFunctions.ValidatePeriod(Period);

            DateFunctions.ValidateQuarter(Quarter);

            DateFunctions.ValidateWeek(Week, Year);

            if ((Year < 1) || (Year > 9999))
            { throw new Exception("Year cannot be less than 1 or greater than 9999."); }

            this.Date = Date;

            this.DayOfYear = DayOfYear;

            this.Period = Period;

            this.Quarter = Quarter;

            this.Week = Week;

            this.Year = Year;
        }
        #endregion
    }
}