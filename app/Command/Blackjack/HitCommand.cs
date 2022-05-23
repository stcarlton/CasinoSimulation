using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;
using System.Threading.Tasks;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI hit button with hit function in the model
    /// Controls hit animations
    /// </summary>
    public class HitCommand : TableCommand
    {
        public HitCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            int delayCounter = 0;

            _vm.CardSound.Play();
            _vm.AnimateHitPlayer();
            _vm.ToggleButtons();
            _vm.RefreshButtons();

            delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
            _vm.DealCard(delayCounter, _model.Raymond);
            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _vm.ToggleButtons();
                _vm.RefreshButtons();
                _vm.RefreshWinnings();
            });
        }
    }
}