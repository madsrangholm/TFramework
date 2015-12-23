using System;

namespace TFramework.BLL.Datatypes.Ticks
{
    public class TickBase
    {
        public DateTime Timestamp { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}