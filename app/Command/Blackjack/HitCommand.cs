using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{   
    public class HitCommand : TableCommand
    {
        public HitCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.HitPlayer(_model.Raymond);
            _vm.RefreshButtons();
            _vm.RefreshDealer();
            _vm.RefreshHuman();
            _vm.RefreshWinnings();
        }
    }
}