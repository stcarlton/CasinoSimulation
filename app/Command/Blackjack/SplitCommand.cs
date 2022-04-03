using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;
using System.Threading.Tasks;

namespace CasinoSimulation.Command.Blackjack
{   
    public class SplitCommand : TableCommand
    {
        public SplitCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            int delayCounter = 0;

            _vm.AnimateHitPlayer();
            _vm.AnimateHitSplit();
            _model.SplitUpPlayer((Human)_model.Raymond);
            _vm.RefreshHuman();

            delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _model.DealSplitPlayer((Human)_model.Raymond);
                _vm.RefreshBankroll();
                _vm.RefreshButtons();
                _vm.RefreshHuman();
            });
        }
    }
}