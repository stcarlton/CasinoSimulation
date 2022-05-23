using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Abstract button command class containing common button command data
    /// </summary>
    public abstract class TableCommand : ButtonCommand
    {
        protected Table _model;
        protected BlackJackViewModel _vm;
        public TableCommand(Table model, BlackJackViewModel vm)
        {
            _model = model;
            _vm = vm;
        }
    }
}
