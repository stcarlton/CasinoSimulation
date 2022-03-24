using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{   
    public class SplitCommand : TableCommand
    {
        public SplitCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.SplitPlayer((Human)_model.Raymond);
            _vm.RefreshBankroll();
            _vm.RefreshHuman();
            _vm.RefreshButtons();
        }
    }
}