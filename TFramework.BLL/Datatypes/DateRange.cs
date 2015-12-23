using System;

namespace TFramework.BLL.Datatypes
{
    public class DateRange
    {
        public DateRange()
        {
        }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}