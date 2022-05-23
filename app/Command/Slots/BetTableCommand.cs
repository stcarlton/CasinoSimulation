using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Command.Slots
{
    /// <summary>
    /// (Requirement 3.4.2.5)
    /// pops out bet table image
    /// </summary>
    public class BetTableCommand : ButtonCommand
    {
        SlotViewModel _vm;
        User user;
        public BetTableCommand(SlotViewModel _vm, User user)
        {
            this._vm = _vm;
            this.user = user;
        }

        public override void Execute(object parameter)
        {

            int value = Int32.Parse(parameter.ToString());
            if (value == 0)
            {
                _vm.tableOpacity = 0;
            }
            else if (value == 1)
            {
                _vm.tableOpacity = 1;
            }
        }
    }
}
