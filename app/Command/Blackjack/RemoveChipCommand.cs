using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    public class RemoveChipCommand : ButtonCommand
    {
        private BlackJackViewModel _vm;

        public RemoveChipCommand(BlackJackViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            if (_vm.BetChipDisplay.Count == 0) return;
            int amount = _vm.BetChipDisplay[_vm.BetChipDisplay.Count-1].Value;
            _vm.BetValue -= amount;
            _vm.RefreshBet();
        }
    }
}