using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    /// <summary>
    /// Command to navigate between mini games and menu
    /// (Requirement 3.1)
    /// </summary>
    public class MenuCommand : NavigationCommand
    {
        public MenuCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new MenuViewModel(_navigation, _user);
        }
    }
}
