using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System.Diagnostics;

namespace CasinoSimulation.Command.Roulette
{/// <summary>
/// (Requirment 3.3.2.4.2)
/// </summary>
    public class SetCommand : ButtonCommand
    {
        RouletteViewModel _vm;
        User user;
        public SetCommand(RouletteViewModel _vm, User user)
        {
            this._vm = _vm;
            this.user = user;
        }
        /*
         this was originally just a textbox, but has been transformed into using chips, however unlike blackjack this form only uses the parameter to cut down the size.

        sets value using chips to bet active and bet sets / bankroll

        clicking on chip will remove the top chip parameter : -100

        other chip presses : +x value
        
        chip presses then effect latter betset betactive user.bankroll and chipstacks
         */
        public override void Execute(object parameter)
        {
            //Requirement 3.3.1.1.1 and 3.3.2.4.2
            int amount = int.Parse(parameter.ToString());
            if (amount == -100) //remove chip test
            {
                if (_vm.BetSets[_vm.BetSetIValue] > 0) //_vm.BetSets[_vm.BetSetIValue] holds the value for each bet 
                {
                    if (_vm.SetChipDisplay == null)
                    {
                        return;
                    }
                    user.Bankroll += _vm.SetChipDisplay[_vm.SetChipDisplay.Count - 1].Value;
                    _vm.ChipStackDisplay = user.Bankroll;
                    _vm.BetSets[_vm.BetSetIValue] -= _vm.SetChipDisplay[_vm.SetChipDisplay.Count - 1].Value;
                    _vm.BetActive = _vm.BetSets[_vm.BetSetIValue];
                    if (user.Bankroll >= 0)
                    {
                        _vm.CanSpin = true;
                        if (user.Bankroll > 0)
                        {
                            _vm.CanBet = true;
                        }
                    }


                }
            }
            else
            {
                _vm.BetSets[_vm.BetSetIValue] += amount;
                _vm.BetActive = _vm.BetSets[_vm.BetSetIValue];


                _vm.ChipStackDisplay -= amount;
                user.Bankroll -= amount;

                if (user.Bankroll <= 0)
                {
                    _vm.CanBet = false;
                    if (user.Bankroll < 0)
                    {
                        _vm.CanSpin = false;
                    }
                }
            }

            _vm.RefreshData();
        }
    }
}
