using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zoo_Navigator.Common
{
    class RCO :ICommand
    {
        private Action<object> _m;

        public RCO(Action<object> m)
        {
            _m = m;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _m(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
