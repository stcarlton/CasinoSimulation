using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Model.Global
{
    public class Navigation
    {
        private ViewModelBase _currentViewModel;
        public Navigation()
        {

        }
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }

            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}

