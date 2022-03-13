using CasinoSimulation.Model.Global;

namespace CasinoSimulation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Navigation _navigation;
        public ViewModelBase CurrentViewModel => _navigation.CurrentViewModel;

        public MainViewModel(Navigation navigationStore)
        {
            _navigation = navigationStore;
            _navigation.CurrentViewModelChanged += ViewModelChange;
        }

        private void ViewModelChange()
        {
            OnPropertyChanged("CurrentViewModel");
        }
    }
}
