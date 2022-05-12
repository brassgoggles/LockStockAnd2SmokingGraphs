using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs.Models
{
    public class StockTicker
    {
        // Was going to use this class for further stock data but
        // did not get around to it and it would require additional API calls.

        // TODO: Demonstrate retrieving this data from an SQL db.
        public bool Active { get; set; }
        public string Cik { get; set; }
        public string CompositeFigi { get; set; }
        public string CurrencyName { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public string Locale { get; set; }
        public string Market { get; set; }
        public string Name { get; set; }
        public string PrimaryExchange { get; set; }
        public string ShareClassFigi { get; set; }
        public string Ticker { get; set; }
        public string Type { get; set; }
    }
}
