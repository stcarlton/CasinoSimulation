using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    public class NextHandCommand : TableCommand
    {
        public NextHandCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.SettleHand((Human)_model.Raymond);
            _vm.RefreshHuman();
            _vm.RefreshWinnings();
            _vm.RefreshBankroll();
            _vm.RefreshButtons();
        }
    }
}