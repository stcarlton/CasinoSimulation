using CasinoSimulation.ViewModel;
using System.Diagnostics;

namespace CasinoSimulation.Command.Roulette
{
    public class BetGenericCommand : ButtonCommand
    {
        RouletteViewModel _vm;
        public BetGenericCommand(RouletteViewModel _vm)
        {
            this._vm = _vm;
            //Debug.WriteLine("1111");
        }
        public override void Execute(object parameter)
        {
            //
            _vm.ActiveValue = parameter.ToString();
            if(_vm.ActiveValue == "Red" || _vm.ActiveValue == "Black")
            {
                if(_vm.ActiveValue == "Red")
                {
                    _vm.BetActive = _vm.BetSets[37];
                }
                else
                {
                    _vm.BetActive = _vm.BetSets[3];
                }
                
            }
            else
            {
                int butttonPressed = (int.Parse(parameter.ToString()));
                _vm.BetActive = _vm.BetSets[butttonPressed];
            }


           
            Debug.WriteLine(_vm.Active);
            
    

        }
    }
}
