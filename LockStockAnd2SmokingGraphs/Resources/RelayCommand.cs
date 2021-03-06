using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LockStockAnd2SmokingGraphs
{
    public class RelayCommand : ICommand
    {
        // Pure "Copy/Paste" job from
        // https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern
        // Essentially the "RelayCommand" is supposed to be a simplified
        // version of the DelegateCommand found in the "Microsoft Composite Application Library".

        #region Fields 
        readonly Action<object> _execute; // Is this basically a function?
        readonly Predicate<object> _canExecute; // Never heard of Predicate before
        #endregion

        #region Constructors 
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members 
        // This seems like a really good idea but I do not know how to use it.
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) { _execute(parameter); }
        #endregion
    }
}
