using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TFramework.BLL.Datatypes;

namespace TFramework.Service.HistoricalData
{
    public static class ConversionHelper
    {
        public static DateTime ToDateTime(this string text)
        {
            var year = Convert.ToInt32(text.Substring(0, 4));
            var month = Convert.ToInt32(text.Substring(4, 2));
            var day = Convert.ToInt32(text.Substring(6, 2));
            var hour = Convert.ToInt32(text.Substring(9, 2));
            var minute = Convert.ToInt32(text.Substring(12, 2));
            var second = Convert.ToInt32(text.Substring(15, 2));
            var milliseconds = Convert.ToInt32(text.Substring(18, 3));
            return new DateTime(year, month, day, hour, minute, second).AddMilliseconds(milliseconds);
        }

        public static Currency ToCurrency(this string text)
        {
            switch (text.ToLower())
            {
                case "eur": 
                    return Currency.Eur;
                case "usd":
                    return Currency.Usd;
                default: return Currency.Dkk;
                        
            }
        }
    }
}