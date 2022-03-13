using CasinoSimulation.ViewModel;
using System.Diagnostics;

namespace CasinoSimulation.Command.Roulette
{
    public class SpinCommand : ButtonCommand
    {
        RouletteViewModel _vm;
        public SpinCommand(RouletteViewModel _vm)
        {
            this._vm =  _vm;
        }
        public override void Execute(object parameter)
        {
            _vm.wheel.getNumber();
            _vm.RefreshData();
            
            _vm.RotateAngle = _vm.wheel.degree;
            for(int i = 0; i < 37; i++)
            {
                if(i<=36)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[i] * 36;
                }
                
            }
            if(_vm.wheel.i % 2 == 0)
            {
                _vm.ChipStackDisplay += _vm.BetSets[37] * 2;
            }
            else
            {
                _vm.ChipStackDisplay += _vm.BetSets[38] * 2;
            }
        }
    }
}
