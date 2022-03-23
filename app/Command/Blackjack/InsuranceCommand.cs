using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    public class InsuranceCommand : TableCommand
    {
        public InsuranceCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.BuyInsurance(_vm.BetValue);
            _vm.RefreshWinnings();
            _vm.RefreshBankroll();
        }
    }
}