using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TFramework.BLL.Datatypes;
using TFramework.BLL.Datatypes.Ticks;
using TFramework.BLL.Interfaces.DAL;

namespace TFramework.Service.HistoricalData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IHistoricalTrueFxService
    {
        private static readonly object Lock = new object();
        private static readonly ObjectCache Cache = MemoryCache.Default;
        public IEnumerable<CurrencyExchangeTick> GetTicks(DateRange range)
        {
            lock (Lock)
            {
                var cachedList = Cache.Get("1234") as List<CurrencyExchangeTick>;
                if (cachedList != null)
                {
                    return cachedList;
                }
                var generatedList = ReadFile();

                Cache.Set("1234", generatedList, new CacheItemPolicy());
                
                return generatedList;
            }         
        }

        public List<CurrencyExchangeTick> ReadFile()
        {
            var tickList = new List<CurrencyExchangeTick>();
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Deploys\EURUSD-2012-11.csv");
            while ((line = file.ReadLine()) != null)
            {
                string[] substrings = line.Split(',');
                var name = substrings[0];
                var currencies = name.Split('/');
                var fromCurrency = currencies[0].ToCurrency();
                var toCurrency = currencies[1].ToCurrency();
                var date = substrings[1].ToDateTime();
                decimal bid = Convert.ToDecimal(substrings[2]);
                decimal ask = Convert.ToDecimal(substrings[3]);
                var result = new CurrencyExchangeTick()
                {
                    Ask = ask,
                    Bid = bid,
                    From = fromCurrency,
                    Timestamp = date,
                    To = toCurrency
                };
                tickList.Add(result);
            }

            file.Close();
            return tickList;
        } 
    }
}
