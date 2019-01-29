using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_UITest.Commands
{
    public class RunCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;

        public RunCommand(Action<object> execute)
           : this(execute, DefaultCanExecute)
        {
        }
        public RunCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            if (canExecute == null) throw new ArgumentNullException("canExecute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute != null && _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}
