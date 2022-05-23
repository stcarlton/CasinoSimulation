using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI next hand button to cycling to settling the current hand and cycling to the next one in the model
    /// </summary>
    public class NextHandCommand : TableCommand
    {
        public NextHandCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.SettleHand((Human)_model.Raymond);
            ((Human)_model.Raymond).InsuranceBet = 0;
            _vm.RefreshBankroll();
            _vm.RefreshButtons();
            _vm.RefreshHuman();
            _vm.RefreshInsurance();
            _vm.RefreshWinnings();
            _vm.ResetBet();
        }
    }
}