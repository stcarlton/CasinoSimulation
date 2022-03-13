using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System.Diagnostics;

namespace CasinoSimulation.Command.Roulette
{
    public class SetCommand : ButtonCommand
    {
        RouletteViewModel _vm;
        User user;
        public SetCommand(RouletteViewModel _vm, User user)
        {
            this._vm = _vm;
            this.user = user;
        }
        public override void Execute(object parameter)
        {

            if (_vm.ActiveValue == "Red" || _vm.ActiveValue == "Black")
            {
                if (_vm.ActiveValue == "Red")
                {
                    _vm.BetSets[37] = _vm.BetValue;
                }
                else
                {
                    _vm.BetSets[38] = _vm.BetValue;
                }
                _vm.BetActive = _vm.BetValue;

            }
            else
            {
                _vm.BetSets[long.Parse(_vm.ActiveValue)] = _vm.BetValue;
                _vm.BetActive = _vm.BetValue;
            }
            _vm.ChipStackDisplay -= _vm.BetValue;
            this.user.Bankroll  -= _vm.BetValue;
        }
    }
}
