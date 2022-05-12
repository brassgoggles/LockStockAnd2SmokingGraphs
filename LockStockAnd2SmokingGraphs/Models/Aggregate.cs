using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs.Models
{
    public class AggregatesResponse
    {
        public string Ticker { get; set; }
        public int QueryCount { get; set; }
        public int ResultsCount { get; set; }
        public bool Adjusted { get; set; }
        public List<Aggregate> Results { get; set; }
        public string Status { get; set; }
        public string RequestId { get; set; }
        public int Count { get; set; }

        public AggregatesResponse() { }

        public AggregatesResponse(string ticker, int queryCount, 
            int resultsCount, bool adjusted, 
            List<Aggregate> results, string status, 
            string requestId, int count)
        {
            Ticker = ticker;
            QueryCount = queryCount;
            ResultsCount = resultsCount;
            Adjusted = adjusted;
            Results = results;
            Status = status;
            RequestId = requestId;
            Count = count;
        }
    }

    public class Aggregate
    {
        // TODO: Use more descriptive naming.
        // I have used the same naming as the API documents to save time.
        public long V { get; set; }
        public double VW { get; set; }
        public double O { get; set; }
        public double C { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public long T { get; set; }
        public int N { get; set; }

        // Did this first, then realized Newtonsoft's Deserialize method will only work
        // if you match the naming convetions properly. Can probably set some sort of
        // alias for the properties.

        //public long TradingVolume { get; set; }
        //public double VolumeWeightedAveragePrice { get; set; }
        //public double OpeningPrice { get; set; }
        //public double ClosingPrice { get; set; }
        //public double HighestPrice { get; set; }
        //public double LowestPrice { get; set; }
        //public long UnixMsecTimeStamp { get; set; }
        //public int NumberOfTransactions { get; set; }
    }
}
