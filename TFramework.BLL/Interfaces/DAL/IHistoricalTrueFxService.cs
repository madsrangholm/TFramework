using System.Collections.Generic;
using TFramework.BLL.Datatypes;
using TFramework.BLL.Datatypes.Ticks;

namespace TFramework.BLL.Interfaces.DAL
{
    public interface IHistoricalTrueFxService
    {
        /// <summary>
        ///     Returns list of historical ticks within the given date range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        IEnumerable<CurrencyExchangeTick> GetTicks(DateRange range);
    }
}