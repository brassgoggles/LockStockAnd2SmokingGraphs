using LockStockAnd2SmokingGraphs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs.Data
{
    public class DbServices
    {
        // TODO: Research how to properly secure a connection string in WPF.
        // Use config file?
        private const string _connString = "Server=tcp:turtleshellsoftwaretestserver.database.windows.net,1433;" +
                    "Initial Catalog=LockStockAnd2SmokingGraphsDb;Persist Security Info=False;" +
                    "User ID=Turtleshell;Password={ Your password here };MultipleActiveResultSets=False;" +
                    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbServices() { }

        public async Task<StockTicker> GetStockTickerData(string ticker)
        {
            using (LockStockAnd2SmokingGraphsContext context = new LockStockAnd2SmokingGraphsContext(_connString))
            {
                StockTicker stockTicker = new StockTicker();

                try
                {
                    stockTicker = (await context.StockTickers.Where(st => st.Ticker == ticker)
                        .ToListAsync()).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    // TODO: Display Alert "Unable to retrieve Ticker information at this time. Please try again later."
                    Console.WriteLine($"********** GetStockTickerData Exception: {ex} **********");
                }

                return stockTicker;
            }            
        }
    }
}
