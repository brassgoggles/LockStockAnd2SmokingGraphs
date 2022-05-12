using LockStockAnd2SmokingGraphs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs
{
    public class DataServices
    {
        static HttpClient client = new HttpClient();
        // TODO: Probably put the request string in a better place (config file?).
        private string ApiKey = "uuG2MxymzRzvOqYKhNVZrMkOxFDRys7u";

        public async Task<AggregatesResponse> GetAggregatesAsync(string ticker, DateTime startDate, DateTime endDate)
        {
            // Format start/end date for request string.
            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = endDate.ToString("yyyy-MM-dd");

            // TODO: Look at a "nicer" way to build the request string.
            string path = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/{startDateString}/{endDateString}?adjusted=true&sort=asc&limit=120&apiKey={ApiKey}";

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                AggregatesResponse responseObj = JsonConvert.DeserializeObject<AggregatesResponse>(jsonString);

                return responseObj;
            }
            return null;
        }

        //public async Task<StockTicker> GetStockDataAsync()
        //{
        //    string path = "https://api.polygon.io/v3/reference/tickers?active=true&sort=ticker&order=asc&limit=10&apiKey=";
        //    string uri = path + ApiKey;

        //    StockTicker ticker = null;

        //    HttpResponseMessage response = await client.GetAsync(uri);

        //    if (response.IsSuccessStatusCode)
        //    {

        //        var jsonString = await response.Content.ReadAsStringAsync();
        //        AggregateResponse responseObj = JsonConvert.DeserializeObject<AggregateResponse>(jsonString);

        //        ticker = responseObj.Results[0];
        //    }
        //    return ticker;
        //}

        //public async Task<string> GetStockDataAsync()
        //{
        //    string path = "https://api.polygon.io/v2/aggs/grouped/locale/us/market/stocks/2020-10-14?adjusted=true&apiKey=";
        //    string uri = path + ApiKey;

        //    HttpResponseMessage response = await client.GetAsync(uri);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string myString = await response.Content.ReadAsStringAsync();
        //        return myString;
        //    }
        //    return "";
        //}
    }
}
