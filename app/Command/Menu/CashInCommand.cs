using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    /// <summary>
    /// Receive initial play chips
    /// (Requirement 3.1.1.1.1)
    /// </summary>
    class CashInCommand : ButtonCommand
    {
        private MenuViewModel _vm;
        private User _user;

        public CashInCommand(MenuViewModel vm, User user)
        {
            _vm = vm;
            _user = user;
        }

        public override void Execute(object parameter)
        {
            _user.CashIn();
            _vm.RefreshChipStack();
        }
    }
}
