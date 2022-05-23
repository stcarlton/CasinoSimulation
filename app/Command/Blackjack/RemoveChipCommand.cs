using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI remove chip button to view model
    /// </summary>
    public class RemoveChipCommand : ButtonCommand
    {
        private BlackJackViewModel _vm;

        public RemoveChipCommand(BlackJackViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            _vm.ChipSound.Play();
            if (_vm.BetChipDisplay.Count == 0)
            {
                return;
            }
            _vm.BetValue -= _vm.BetChipDisplay[_vm.BetChipDisplay.Count - 1].Value;
            _vm.RefreshBet();
        }
    }
}