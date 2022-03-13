using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    public class SlotsCommand : NavigationCommand
    {
        public SlotsCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new SlotViewModel(_navigation, _user);
        }
    }
}
