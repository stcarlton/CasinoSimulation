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
            if (_vm.BetChipDisplay == null)
            {
                return;
            }
            _vm.BetValue -= _vm.BetChipDisplay[_vm.BetChipDisplay.Count - 1].Value;
        }
    }
}