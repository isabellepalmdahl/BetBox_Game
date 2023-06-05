using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace supX.Commands
{
    /// <summary>
    /// Help class to be able to use bindings with methods
    /// </summary>
    class RelyCommand : ICommand
    {
        #region Variables
        private Action action;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Constructors
        public RelyCommand(Action action)
        {
            this.action = action;
        }
        #endregion

        #region Public Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
        #endregion
    }
}
