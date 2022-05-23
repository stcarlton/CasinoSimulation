using CasinoSimulation.ViewModel;
using System;
using System.Diagnostics;

namespace CasinoSimulation.Command.Roulette
{/// <summary>
/// (Requirement 3.3.2.3) and 3.3.1.2
/// </summary>
    public class SpinCommand : ButtonCommand
    {
        RouletteViewModel _vm;
        public SpinCommand(RouletteViewModel _vm)
        {
            this._vm = _vm;

        }
        /*This command does not spin the wheel, but checks whether the player would win there number of bets
         then it updates the next the spinners next degree number for when the spin button is hit.
         */

        public override void Execute(object parameter)//3.3.2.3
        {
            int number = _vm.wheel.number; // grabs number on wheel

            /*to test lane*/
            if (number != 0)
            {
                if (number % 3 == 1)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[46] * 3;
                }
                else if (number % 3 == 2)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[47] * 3;
                }
                else
                {
                    _vm.ChipStackDisplay += _vm.BetSets[48] * 3;
                }
                //to test <> 18 bets
                if (number <= 18 && number > 0)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[41] * 2;
                }
                else if (number > 18)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[42] * 2;
                }
                //test 12's

                if (number <= 12)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[43] * 3;
                }
                else if (number <= 24)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[44] * 3;
                }
                else
                {
                    _vm.ChipStackDisplay += _vm.BetSets[45] * 3;

                }
                //test odd or even
                if (number % 2 == 0)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[39] * 2;
                }
                else
                {
                    _vm.ChipStackDisplay += _vm.BetSets[40] * 2;
                }
                //test red or black
                if (_vm.wheel.i % 2 == 0)
                {
                    _vm.ChipStackDisplay += _vm.BetSets[37] * 2;
                }
                else
                {
                    _vm.ChipStackDisplay += _vm.BetSets[38] * 2;
                }

                _vm.ChipStackDisplay += _vm.BetSets[number] * 36;
            }
            Array.Clear(_vm.BetSets, 0, _vm.BetSets.Length);

            _vm.BetActive = 0;
            _vm.RefreshData();
            _vm.RefreshWheel();
            _vm.wheel.getNumber(); // grabs the next random number
            _vm.RotateAngle = _vm.wheel.degree + 360;


        }
    }
}
/* if(_vm.ActiveValue == "Red")
            {
                    _vm.
= _vm.BetSets[37];
            }
            else if(_vm.ActiveValue == "Black")
            {
                _vm.BetActive = _vm.BetSets[38];
            }
            else if (_vm.ActiveValue == "Even")
            {
                _vm.BetActive = _vm.BetSets[39];
            }
            else if (_vm.ActiveValue == "Odd")
            {
                _vm.BetActive = _vm.BetSets[40];
            }
            else if (_vm.ActiveValue == "1_18")
            {
                _vm.BetActive = _vm.BetSets[41];
            }
            else if (_vm.ActiveValue == "19_36")
            {
                _vm.BetActive = _vm.BetSets[42];
            }
            else if (_vm.ActiveValue == "1_12")
            {
                _vm.BetActive = _vm.BetSets[43];
            }
            else if (_vm.ActiveValue == "2_12")
            {
                _vm.BetActive = _vm.BetSets[44];
            }
            else if (_vm.ActiveValue == "3_12")
            {
                _vm.BetActive = _vm.BetSets[45];
            }
            else if (_vm.ActiveValue == "2_1Top")
            {
                _vm.BetActive = _vm.BetSets[46];
            }
            else if (_vm.ActiveValue == "2_1Mid")
            {
                _vm.BetActive = _vm.BetSets[47];
            }
            else if (_vm.ActiveValue == "2_1Bot")
            {
                _vm.BetActive = _vm.BetSets[48];
            }*/