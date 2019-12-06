﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zoo_Navigator.Common
{
    class RelayCommand : ICommand
    {
        private Action _action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}
