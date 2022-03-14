using CasinoSimulation.Model.Global;

namespace CasinoSimulation.Command.Menu
{
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
