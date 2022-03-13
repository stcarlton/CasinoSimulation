using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    public class SlotViewModel : ViewModelBase
    {
        public ICommand MenuCommand { get; }
        public SlotViewModel(Navigation nav, User user)
        {
            MenuCommand = new MenuCommand(nav, user);
        }
    }
}
