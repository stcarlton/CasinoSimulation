using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{   
    public class DoubleDownCommand : TableCommand
    {
        public DoubleDownCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.DoubleDownPlayer((Human)_model.Raymond);
            _vm.RefreshBankroll();
            _vm.RefreshHuman();
        }
    }
}