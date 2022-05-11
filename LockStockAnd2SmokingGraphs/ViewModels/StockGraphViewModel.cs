using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStockAnd2SmokingGraphs.ViewModels
{
    public class StockGraphViewModel : BaseViewModel
    {
        private string _name = "CAM";

        public string Name
        {
            get { return _name; }
            set
            { 
                _name = value;
                OnPropertyChanged();
            }
        }

        public StockGraphViewModel()
        {
            DataServices db = new DataServices();
            _ = db.GetStockDataAsync();
        }
    }
}
