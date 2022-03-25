using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{   
    public class StandCommand : TableCommand
    {
        public StandCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.StandPlayer(_model.Raymond);
            _vm.RefreshHuman();
            _vm.RefreshDealer();
            _vm.RefreshWinnings();
            _vm.RefreshButtons();
        }
    }
}