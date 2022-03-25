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
            ((Human)_model.Raymond).InsuranceBet = 0;
            _vm.ResetBet();
            _vm.RefreshBankroll();
            _vm.RefreshButtons();
            _vm.RefreshHuman();
            _vm.RefreshInsurance();
            _vm.RefreshWinnings();
        }
    }
}