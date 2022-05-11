using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs.Models
{
    public class ApiResponse
    {
        public int Count { get; set; }
        public string NextUrl { get; set; }
        public string RequestId { get; set; }
        public List<StockTicker> Results { get; set; }
        public string Status { get; set; }

        public ApiResponse() { }

        public ApiResponse(int count, string nextUrl, 
            string requestId, List<StockTicker> results, string status)
        {
            Count = count;
            NextUrl = nextUrl;
            RequestId = requestId;
            Results = results;
            Status = status;
        }
    }
}
