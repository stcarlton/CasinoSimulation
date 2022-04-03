using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;
using System.Threading.Tasks;

namespace CasinoSimulation.Command.Blackjack
{   
    public class DoubleDownCommand : TableCommand
    {
        public DoubleDownCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            int delayCounter = 0;

            _vm.AnimateHitPlayer();

            delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _model.DoubleDownPlayer((Human)_model.Raymond);
                _vm.RefreshBankroll();
                _vm.RefreshButtons();
                _vm.RefreshDealer();
                _vm.RefreshHuman();
                _vm.RefreshWinnings();
                _vm.RefreshBet();
            });

        }
    }
}