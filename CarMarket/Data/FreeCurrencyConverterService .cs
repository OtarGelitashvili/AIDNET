using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarMarket.Data
{
    public class FreeCurrencyConverterService:IFreeCurrencyConverterService
    {
        private readonly String BASE_URI = "https://free.currconv.com";
        private readonly String API_VERSION = "v7";
        private readonly String API_KEY = "1354ee5fb982692797a5";

        public FreeCurrencyConverterService() { }

        public Decimal GetCurrencyExchange(String localCurrency, String foreignCurrency)
        {
            var code = $"{localCurrency}_{foreignCurrency}";
            var newRate = FetchSerializedData(code);
            return newRate;
        }

        public Decimal FetchSerializedData(String code)
        {
            var url = $"{BASE_URI}/api/{API_VERSION}/convert?q={code}&compact=ultra&apiKey={API_KEY}";
            var webClient = new WebClient();
            var jsonData = String.Empty;

            var conversionRate = 1.0m;
            try
            {
                jsonData = webClient.DownloadString(url);
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(jsonData);
                var result = jsonObject[code];
                conversionRate = result;

            }
            catch (Exception) { }

            return conversionRate;
        }
    }
}
