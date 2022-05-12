using LockStockAnd2SmokingGraphs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LockStockAnd2SmokingGraphs.ViewModels
{
    public class StockGraphViewModel : BaseViewModel
    {
        #region Properties
        private string[] Tickers = {"TSLA", "MSFT", "AMZN", "GOOG", "AAPL"};
        private List<KeyValuePair<string, List<Aggregate>>> AllAggregatesData;
        private DateTime startDate;
        private DateTime endDate;

        private ObservableCollection<KeyValuePair<string, double>> _todaysClosingData;

        public ObservableCollection<KeyValuePair<string, double>> TodaysClosingData
        {
            get { return _todaysClosingData; }
            set { _todaysClosingData = value; OnPropertyChanged(); }
        }

        private ObservableCollection<KeyValuePair<string, double>> _lineData;

        public ObservableCollection<KeyValuePair<string, double>> LineData
        {
            get { return _lineData; }
            set { _lineData = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        private ICommand _getAggregateDataCommand;

        public ICommand GetAggregateDataCommand
        {
            get
            {
                if (_getAggregateDataCommand == null)
                {
                    _getAggregateDataCommand = new RelayCommand(param => {

                        List<Aggregate> aggregateData = AllAggregatesData.Where(a => a.Key == param.ToString()).FirstOrDefault().Value;

                        LineData = new ObservableCollection<KeyValuePair<string, double>>();

                        int i = 1;

                        // Build all the KeyValuePairs required for line graph, using
                        // the date in correct format and the Closing stock value for the day.
                        foreach (var aggregate in aggregateData)
                        {
                            LineData.Add(new KeyValuePair<string, double>(
                                startDate.AddDays(i).ToString("yyyy-MM-dd"), aggregate.C));
                            i++;
                        }
                    });
                }
                return _getAggregateDataCommand;
            }
        }
        #endregion

        public StockGraphViewModel()
        {
            InitData();
        }

        private async void InitData()
        {
            DataServices db = new DataServices();

            endDate = DateTime.Now.AddDays(-1);
            startDate = endDate.AddDays(-6);

            TodaysClosingData = new ObservableCollection<KeyValuePair<string, double>>();
            AllAggregatesData = new List<KeyValuePair<string, List<Aggregate>>>();

            foreach (var ticker in Tickers)
            {
                AggregatesResponse responseObj = await db.GetAggregatesAsync(ticker, startDate, endDate);
                TodaysClosingData.Add(new KeyValuePair<string, double>(responseObj.Ticker, responseObj.Results.LastOrDefault().C));

                // Cache "AllAggregatesData" to call assign to the LineData when ever required.
                AllAggregatesData.Add(new KeyValuePair<string, List<Aggregate>>(responseObj.Ticker, responseObj.Results));
            }
        }
    }
}
