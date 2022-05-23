using CasinoSimulation.Model.Global;

namespace CasinoSimulation.Command.Menu
{
    /// <summary>
    /// Abstract class to hold common data for navigation commands
    /// </summary>
    public abstract class NavigationCommand : ButtonCommand
    {
        protected Navigation _navigation;
        protected User _user;
        public NavigationCommand(Navigation navigation, User user)
        {
            _navigation = navigation;
            _user = user;
        }
    }
}
