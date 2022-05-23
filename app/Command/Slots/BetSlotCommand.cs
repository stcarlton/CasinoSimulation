using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Command.Slots
{
    /// <summary>
    /// (Requirement 3.4.2.2) either updates up by 100 or 300
    /// </summary>
    public class BetSlotCommand : ButtonCommand
    {
        SlotViewModel _vm;
        User user;
        public BetSlotCommand(SlotViewModel _vm, User user)
        {
            this._vm = _vm;
            this.user = user;
        }
        public override void Execute(object parameter)
        {
            int value = Int32.Parse(parameter.ToString());
            if (_vm.CoinsPlayed != 300 || _vm.HasSpun == true) //(Requirement 3.4.2.2.1) and 3.4.1.1.1, 3.4.1.1.2. and 3.4.2.2.1 and 3.4.2.3
            {
                if (_vm.HasSpun == true)
                {
                    _vm.CoinsPlayed = 0;
                }
                if (value == 300 && _vm.Credits >= 300)
                {
                    _vm.Credits -= 300 - _vm.CoinsPlayed;
                    _vm.CoinsPlayed = 300;



                }
                if (value == 100 && _vm.Credits >= 100)
                {
                    _vm.CoinsPlayed += 100;
                    _vm.Credits -= 100;
                }
                _vm.HasSpun = false;
            }


        }
    }
}
