using System;
using CasinoSimulation.Model.Global;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CasinoSimulation.Command
{
    /// <summary>
    /// abstract class to hold shared data and functions between all button commands
    /// </summary>
    public abstract class ButtonCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public abstract void Execute(object parameter);
        public void OnCanExecutedChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
