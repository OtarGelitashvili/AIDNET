using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMarket.Data
{
    public interface IFreeCurrencyConverterService
    {
        public Decimal GetCurrencyExchange(String localCurrency, String foreignCurrency);
        public Decimal FetchSerializedData(String code);
    }
}
