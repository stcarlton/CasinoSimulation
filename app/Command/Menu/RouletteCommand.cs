using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    /// <summary>
    /// Command to navigate between menu and roulette
    /// (Requirement 3.1)
    /// </summary>
    public class RouletteCommand : NavigationCommand
    {
        public RouletteCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new RouletteViewModel(_navigation, _user);
        }
    }
}
