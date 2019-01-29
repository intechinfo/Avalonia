using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_UITest.Commands
{
    public interface ICommand
    {
        bool CanExecute(object parameter);
        void Execute(object parameter);
        event EventHandler CanExecuteChanged;
    }
}
