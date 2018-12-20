using System;
using System.Collections.Generic;

namespace MerchandisingCalendar
{
    public class DateRange
    {
        #region PROPERTIES
        public virtual DateTime EndDate { get; set; }

        public virtual DateTime StartDate { get; set; }
        #endregion

        #region CONSTRUCTOR
        public DateRange(DateTime StartDate, DateTime EndDate)
        {
            this.EndDate = EndDate;

            this.StartDate = StartDate;

            Validate();
        }
        #endregion

        #region METHODS
        public IEnumerable<DateTime> GetDatesInRange()
        {
            for (DateTime _DateTime = StartDate.Date; _DateTime <= EndDate.Date; _DateTime = _DateTime.AddDays(1))
            { yield return _DateTime; }
        }

        public IEnumerable<MerchandisingDate> GetMerchandisingDatesInRange()
        {
            for (DateTime _DateTime = StartDate.Date; _DateTime <= EndDate.Date; _DateTime = _DateTime.AddDays(1))
            { yield return new MerchandisingDate(_DateTime); }
        }

        public void Validate()
        {
            if (StartDate > EndDate)
            { throw new InvalidDateRangeException(this); }
        }
        #endregion
    }
}