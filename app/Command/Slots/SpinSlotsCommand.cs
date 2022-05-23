using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using CasinoSimulation.Model.Slots;
using CasinoSimulation.ViewModel;
namespace CasinoSimulation.Command.Slots
{/// <summary>
/// (Requirement 3.4.2.3) splins slots and finds next spin location
/// </summary>
    public class SpinSlotsCommand : ButtonCommand
    {
        SlotViewModel _vm;
        Random r = new Random();
        public SpinSlotsCommand(SlotViewModel _vm)
        {
            this._vm = _vm;
        }
        public override void Execute(object parameter)
        {
            Random r = new Random();
            int[] locations = new int[] { -2770, -3160, -3560, -3945, -4345, -4735, -5135 };
            //update version uses multiple classes for future slots sepperated for future slots, but it might be later removed


            //Slot items use for comparison for betting comparisons
            SlotItem slt1Item = _vm.line1._items[_vm.Llines.line1];


            SlotItem slt2Item = _vm.line2._items[_vm.Llines.line2];


            SlotItem slt3Item = _vm.line3._items[_vm.Llines.line3];

            //rholder information use to show random is working
            _vm.slt3 = slt3Item.Name.ToString() + " " + slt3Item.Color.ToString() + " " + _vm.Llines.line3;

            _vm.slt2 = slt2Item.Name.ToString() + " " + slt2Item.Color.ToString() + " " + _vm.Llines.line2;

            _vm.slt1 = slt1Item.Name.ToString() + " " + slt1Item.Color.ToString() + " " + _vm.Llines.line1;
            //3.4.2.3
            int rholder = r.Next(7);
            _vm.Llines.line1 = rholder;
            _vm.Leftline = locations[_vm.Llines.line1];
            rholder = r.Next(7);
            _vm.Llines.line2 = rholder;
            _vm.Midline = locations[_vm.Llines.line2];
            rholder = r.Next(7);
            _vm.Llines.line3 = rholder;
            _vm.Rightline = locations[_vm.Llines.line3];
            if (_vm.HasSpun == true && _vm.Credits >= 300) //3.4.2.3
            {
                _vm.Credits -= _vm.CoinsPlayed;
            }
            if (_vm.HasSpun == true && _vm.CoinsPlayed > _vm.Credits) //3.4.2.3
            {
                _vm.CoinsPlayed = 0;
            }
            //if span regularly will bet max // create a delay so the player can see it use a while loop 3.4.2.3
            if (_vm.CoinsPlayed == 0 && _vm.Credits >= 300)
            {
                _vm.CoinsPlayed = 300;
                _vm.Credits -= 300;
            }
            //goes down from best bet to worst 3.4.2.3
            if (slt3Item.Name.ToString() == "wild" && slt2Item.Name.ToString() == "wild" && slt1Item.Name.ToString() == "wild")
            {
                if (_vm.CoinsPlayed == 3)
                {
                    _vm.Credits += 20 * _vm.CoinsPlayed;
                    _vm.PaidAmount = 20 * _vm.CoinsPlayed;
                }
                else
                {
                    _vm.Credits += 20 * _vm.CoinsPlayed;
                    _vm.PaidAmount = 20 * _vm.CoinsPlayed;
                }
            }
            else if (slt3Item.Name.ToString() == "seven" && slt2Item.Name.ToString() == "seven" && slt1Item.Name.ToString() == "seven"
                && slt3Item.Color.ToString() == "blue" && slt2Item.Color.ToString() == "white" && slt1Item.Color.ToString() == "red")
            {
                _vm.Credits += 9 * _vm.CoinsPlayed;
                _vm.PaidAmount = 9 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "seven" && slt2Item.Name.ToString() == "seven" && slt1Item.Name.ToString() == "seven"
            && slt3Item.Color.ToString() == "red" && slt2Item.Color.ToString() == "red" && slt1Item.Color.ToString() == "red")
            {
                _vm.Credits += 9 * _vm.CoinsPlayed;
                _vm.PaidAmount = 9 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "seven" && slt2Item.Name.ToString() == "seven" && slt1Item.Name.ToString() == "seven"
            && slt3Item.Color.ToString() == "white" && slt2Item.Color.ToString() == "white" && slt1Item.Color.ToString() == "white")
            {
                _vm.Credits += 8 * _vm.CoinsPlayed;
                _vm.PaidAmount = 8 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "seven" && slt2Item.Name.ToString() == "seven" && slt1Item.Name.ToString() == "seven"
            && slt3Item.Color.ToString() == "blue" && slt2Item.Color.ToString() == "blue" && slt1Item.Color.ToString() == "blue")
            {
                _vm.Credits += 7 * _vm.CoinsPlayed;
                _vm.PaidAmount = 7 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "seven" && slt2Item.Name.ToString() == "seven" && slt1Item.Name.ToString() == "seven")
            {
                _vm.Credits += 6 * _vm.CoinsPlayed;
                _vm.PaidAmount = 6 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "bar" && slt2Item.Name.ToString() == "bar" && slt1Item.Name.ToString() == "bar"
            && slt3Item.Color.ToString() == "blue" && slt2Item.Color.ToString() == "blue" && slt1Item.Color.ToString() == "blue")
            {
                _vm.Credits += 5 * _vm.CoinsPlayed;
                _vm.PaidAmount = 5 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "bar" && slt2Item.Name.ToString() == "bar" && slt1Item.Name.ToString() == "bar"
            && slt3Item.Color.ToString() == "white" && slt2Item.Color.ToString() == "white" && slt1Item.Color.ToString() == "white")
            {
                _vm.Credits += 4 * _vm.CoinsPlayed;
                _vm.PaidAmount = 4 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "bar" && slt2Item.Name.ToString() == "bar" && slt1Item.Name.ToString() == "bar"
            && slt3Item.Color.ToString() == "red" && slt2Item.Color.ToString() == "red" && slt1Item.Color.ToString() == "red")
            {
                _vm.Credits += 3 * _vm.CoinsPlayed;
                _vm.PaidAmount = 3 * _vm.CoinsPlayed;
            }
            else if (slt3Item.Name.ToString() == "bar" && slt2Item.Name.ToString() == "bar" && slt1Item.Name.ToString() == "bar")
            {
                _vm.Credits += 1 * _vm.CoinsPlayed;
                _vm.PaidAmount = 1 * _vm.CoinsPlayed;
            }
            else
            {
                _vm.PaidAmount = 0;
            }
            /*
             
             side note for quick enable of bet testing im probably going to create a line using cards
             
             */

            _vm.HasSpun = true;





            /*if(_vm.slt1 == _vm.slt2 && _vm.slt2 == _vm.slt3)
            {
                _vm.slt1 = "win";
                _vm.slt2 = "win";
                _vm.slt3 = "win";

            }*/
            /*
            int delayCounter = 0;
            delayCounter += SlotViewModel.DELAY_MILLISECONDS;
            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _vm.CoinsPlayed = 0;
            });
           
            */

        }
    }
}
