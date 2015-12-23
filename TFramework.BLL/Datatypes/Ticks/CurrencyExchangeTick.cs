namespace TFramework.BLL.Datatypes.Ticks
{
    public class CurrencyExchangeTick : TickBase
    {
        public Currency From { get; set; }
        public Currency To { get; set; }
    }
}