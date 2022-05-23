using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    /// <summary>
    /// Command to navigate between menu and slots
    /// (Requirement 3.1)
    /// </summary>
    public class SlotsCommand : NavigationCommand
    {
        public SlotsCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new SlotViewModel(_navigation, _user);
        }
    }
}
