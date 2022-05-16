using LockStockAnd2SmokingGraphs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs.Data
{
    public class LockStockAnd2SmokingGraphsContext : DbContext
    {
        public LockStockAnd2SmokingGraphsContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<StockTicker> StockTickers { get; set; }
    }
}
