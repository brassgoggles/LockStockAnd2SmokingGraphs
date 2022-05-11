using LockStockAnd2SmokingGraphs.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs
{
    public class DataServices
    {
        static HttpClient client = new HttpClient();
        private string ApiKey = "uuG2MxymzRzvOqYKhNVZrMkOxFDRys7u";

        public async Task<StockTicker> GetStockDataAsync()
        {
            string path = "https://api.polygon.io/v3/reference/tickers?active=true&sort=ticker&order=asc&limit=10&apiKey=";
            string uri = path + ApiKey;

            StockTicker ticker = null;

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {

                var jsonString = await response.Content.ReadAsStringAsync();
                ApiResponse responseObj = JsonConvert.DeserializeObject<ApiResponse>(jsonString);

                ticker = responseObj.Results[0];
            }
            return ticker;
        }

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
