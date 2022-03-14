using System.Windows.Input;
using CasinoSimulation.Command.Menu;
using CasinoSimulation.Command.Roulette;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Model.Roulette;

namespace CasinoSimulation.ViewModel
{
    public class RouletteViewModel : ViewModelBase
    {
        public ICommand MenuCommand { get; }
        public ICommand BetGenericCommand { get; }
        public ICommand SpinCommand { get; }
        public ICommand SetCommand { get; } 

        public int Active;

        public long[] BetSets = new long[40];

        public Wheel wheel = new Wheel();

        public long _WheelNumber;
        public string _ActiveValue;
        public long _BetValue;
        public long _BetActive;
        public long _ChipStackDisplay;
        //MenuViewModel _vm;
        Navigation nav;
        User user;
        double rotateAngle = 0;
        public double RotateAngle
        {
            get
            {
                return rotateAngle;
            }

             set
            {
                    rotateAngle = value;
                    OnPropertyChanged("RotateAngle");
            }
        }
    
    public long ChipStackDisplay
        {
            get
            {
                return _ChipStackDisplay;
            }
            set
            {
                _ChipStackDisplay = value;
                OnPropertyChanged("ChipStackDisplay");
            }
        }
        public long WheelNumber
        {
            get
            {
                return _WheelNumber;
            }
            set
            {
                _WheelNumber = value;
                OnPropertyChanged("WheelNumber");
            }
        }
        public long BetValue
        {
            get
            {
                return _BetValue;
            }
            set
            {
                _BetValue = value;
                OnPropertyChanged("BetValue");
            }
        }
        public long BetActive
        {
            get
            {
                return _BetActive;
            }
            set
            {
                _BetActive = value;
                OnPropertyChanged("BetActive");
            }
        }
        public string ActiveValue
        {
            get
            {
                return _ActiveValue;
            }
            set
            {
                _ActiveValue = value;
                OnPropertyChanged("ActiveValue");
            }
        }
        
        public RouletteViewModel(Navigation nav, User user)
        {
            this.user = user;
            this.nav = nav;
            //this.user.Cash = 5;
            MenuCommand = new MenuCommand(nav, this.user);
            BetGenericCommand = new BetGenericCommand(this);
            SpinCommand = new SpinCommand(this);
            SetCommand = new SetCommand(this, this.user);
            ChipStackDisplay = user.Bankroll;
        }
        public void RefreshData()
        {
            WheelNumber = wheel.number;
        }
    }
}
