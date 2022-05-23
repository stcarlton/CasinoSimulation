using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI stand button to stand function in model and refreshes UI
    /// </summary>
    public class StandCommand : TableCommand
    {
        public StandCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _model.StandPlayer(_model.Raymond);
            _vm.RefreshButtons();
            _vm.RefreshDealer();
            _vm.RefreshHuman();
            _vm.RefreshWinnings();
        }
    }
}