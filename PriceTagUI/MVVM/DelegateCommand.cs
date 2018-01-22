﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceTagUI.MVVM
{
   class DelegateCommand : System.Windows.Input.ICommand
   {
      readonly Action _execute;
      readonly Action<Object> _executeParam;
      readonly Func<Boolean> _canExecute;

      public DelegateCommand(Action action)
      {
         _execute = action;
      }
      
      public DelegateCommand(Action<object> action)
      {
         _executeParam = action;
      }

      public DelegateCommand(Action action, Func<Boolean> func)
      {
         _execute = action;
         _canExecute = func;
      }

      public DelegateCommand(Action<object> action, Func<Boolean> func)
      {
         _executeParam = action;
         _canExecute = func;
      }

      public void Execute(object parameter)
      {
         if(_execute != null)
         {
            _execute.Invoke();
         }
         else if(_executeParam != null)
         {
            _executeParam.Invoke(parameter);
         }
      }

      public Boolean CanExecute(object parameter)
      {
         return (_canExecute == null || _canExecute.Invoke());
      }

      public event EventHandler CanExecuteChanged;
   }
}
