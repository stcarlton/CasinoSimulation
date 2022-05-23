using CasinoSimulation.ViewModel;
using System.Diagnostics;

namespace CasinoSimulation.Command.Roulette
{/// <summary>
/// (Requirement 3.3.2.4.1) used to click on different bets and switch
/// </summary>
    public class BetGenericCommand : ButtonCommand
    {
        RouletteViewModel _vm;
        public BetGenericCommand(RouletteViewModel _vm)
        {
            this._vm = _vm;

        }
        /*instead of using multiple buttons it passes the parameterr, by clicking on a button*/
        public override void Execute(object parameter)
        {
            //used to give information on active bet and find active bet for array 3.3.1.1.1 and 3.3.2.4.1
            _vm.ActiveValue = parameter.ToString();
            if (_vm.ActiveValue == "Red")
            {
                _vm.BetActive = _vm.BetSets[37];
                _vm.BetSetIValue = 37;
            }
            else if (_vm.ActiveValue == "Black")
            {
                _vm.BetActive = _vm.BetSets[38];
                _vm.BetSetIValue = 38;
            }
            else if (_vm.ActiveValue == "Even")
            {
                _vm.BetActive = _vm.BetSets[39];
                _vm.BetSetIValue = 39;
            }
            else if (_vm.ActiveValue == "Odd")
            {
                _vm.BetActive = _vm.BetSets[40];
                _vm.BetSetIValue = 40;
            }
            else if (_vm.ActiveValue == "1_18")
            {
                _vm.BetActive = _vm.BetSets[41];
                _vm.BetSetIValue = 41;
            }
            else if (_vm.ActiveValue == "19_36")
            {
                _vm.BetActive = _vm.BetSets[42];
                _vm.BetSetIValue = 42;
            }
            else if (_vm.ActiveValue == "1_12")
            {
                _vm.BetActive = _vm.BetSets[43];
                _vm.BetSetIValue = 43;
            }
            else if (_vm.ActiveValue == "2_12")
            {
                _vm.BetActive = _vm.BetSets[44];
                _vm.BetSetIValue = 44;
            }
            else if (_vm.ActiveValue == "3_12")
            {
                _vm.BetActive = _vm.BetSets[45];
                _vm.BetSetIValue = 45;
            }
            else if (_vm.ActiveValue == "2_1Top")
            {
                _vm.BetActive = _vm.BetSets[48];
                _vm.BetSetIValue = 48;
            }
            else if (_vm.ActiveValue == "2_1Mid")
            {
                _vm.BetActive = _vm.BetSets[47];
                _vm.BetSetIValue = 47;
            }
            else if (_vm.ActiveValue == "2_1Bot")
            {
                _vm.BetActive = _vm.BetSets[46];
                _vm.BetSetIValue = 46;
            }
            else
            {
                //this is used for buttons with non string values
                int butttonPressed = (int.Parse(parameter.ToString()));
                _vm.BetSetIValue = butttonPressed;
                _vm.BetActive = _vm.BetSets[butttonPressed];
            }

            _vm.RefreshData();





        }
    }
}
