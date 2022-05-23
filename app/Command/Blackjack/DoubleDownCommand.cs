using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;
using System.Threading.Tasks;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI double down button with double down function in the model
    /// Controls double down animations
    /// </summary>
    public class DoubleDownCommand : TableCommand
    {
        public DoubleDownCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            int delayCounter = 0;

            _vm.CardSound.Play();
            _vm.AnimateHitPlayer();
            _vm.ToggleButtons();
            _vm.RefreshButtons();

            delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _model.DoubleDownPlayer((Human)_model.Raymond);
                _vm.RefreshBankroll();
                _vm.ToggleButtons();
                _vm.RefreshButtons();
                _vm.RefreshDealer();
                _vm.RefreshHuman();
                _vm.RefreshWinnings();
                _vm.RefreshBet();
            });

        }
    }
}