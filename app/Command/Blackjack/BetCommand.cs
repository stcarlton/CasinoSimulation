using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    public class BetCommand : ButtonCommand
    {
        private BlackJackViewModel _vm;
        private int _bet;
        
        public BetCommand(BlackJackViewModel vm, int bet)
        {
            _vm = vm;
            _bet = bet;
        }
        public override void Execute(object parameter)
        {
            _vm.BetValue += _bet;
            _vm.OnPropertyChanged("BetChipDisplay");
        }
    }
}