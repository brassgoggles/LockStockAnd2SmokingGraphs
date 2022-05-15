using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LockStockAnd2SmokingGraphs.Resources.UserControls
{
    public partial class DataBlock : UserControl
    {
        public string Title { get; set; }

        // type propdp then tab to auto generate :)
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(DataBlock), new PropertyMetadata(string.Empty));

        public DataBlock()
        {
            InitializeComponent();
            
            // TODO: Is there a better way to do this?
            title.DataContext = this;
            data.DataContext = this;
        }
    }
}
