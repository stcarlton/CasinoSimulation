using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{   
    public class DealCommand : TableCommand
    {
        public DealCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.Deal(_vm.BetValue);
            _vm.RefreshBankroll();
            _vm.RefreshDealer();
            _vm.RefreshHuman();
            _vm.RefreshButtons();
        }
    }
}