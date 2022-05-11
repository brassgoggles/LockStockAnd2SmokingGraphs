using LockStockAnd2SmokingGraphs.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LockStockAnd2SmokingGraphs
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StockGraphView stockGraphView = new StockGraphView();
            //string path = "Data/StockGraphView.xaml";
            var viewModel = new StockGraphViewModel();
            stockGraphView.DataContext = viewModel;
            stockGraphView.Show();
        }
    }
}
