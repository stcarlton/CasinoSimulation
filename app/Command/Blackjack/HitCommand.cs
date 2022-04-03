using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;
using System.Threading.Tasks;

namespace CasinoSimulation.Command.Blackjack
{   
    public class HitCommand : TableCommand
    {
        public HitCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            int delayCounter = 0;

            _vm.AnimateHitPlayer();

            delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
            _vm.DealCard(delayCounter, _model.Raymond);
            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _vm.RefreshButtons();
                _vm.RefreshWinnings();
            });
        }
    }
}