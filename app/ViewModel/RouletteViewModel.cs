using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Threading;
using CasinoSimulation.Command.Menu;
using CasinoSimulation.Command.Roulette;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Model.Roulette;

namespace CasinoSimulation.ViewModel
{
    public class RouletteViewModel : ViewModelBase
    {

        /// <summary>
        /// 2.1
        /// </summary>

        public long[] BetSets = new long[50]; //used to hold BetActive values (Requirement 1.2.3) since all values start at zero 3.3.1.1

        /*wheel model holder
         * used to find degree, number and as a grab
         * (Requirement 1.2.3)
         */
        public Wheel wheel = new Wheel();

        /*
         accessory valuess related only to the vm
         */

        Random rnd = new Random(); //random holder
        double rotateAngle = 0; // rotation value
        public int BetSetIValue; // array I value holder
        string _wheelimage = "/wheelfixed.png"; // image string location for wheel used to clean up screen

        private DispatcherTimer WheelTimer = new DispatcherTimer(); //experiment ignore

        /*
         * viewmodel and view relation values
        */
        public long _WheelNumber; //wheel number display
        public string _ActiveValue; // active locations bet value
        public long _BetActive; // amount of bet for active locaation 
        public long _ChipStackDisplay; // User Bankroll long holder
        public bool _CanBet = false; // value will start false as there should be no value entered 
        public bool _CanSpin = true; // allow the player to spin with no money entered 


        /*
         main model variables used to connect this viewmodel with the menu
         */
        Navigation nav;
        User user;
        /*Property change actions*/
        public bool CanSpin
        {
            get
            {
                return _CanSpin;
            }

            set
            {
                _CanSpin = value;
                OnPropertyChanged("CanSpin");
            }
        }
        public bool CanBet
        {
            get
            {
                return _CanBet;
            }

            set
            {
                _CanBet = value;
                OnPropertyChanged("CanBet");
            }
        }
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
        //3.3.1.1.3
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

        public long BetActive //3.3.2.4
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
        public string WheelImage
        {
            get
            {
                return _wheelimage;
            }
            set
            {
                _wheelimage = value;
                OnPropertyChanged("WheelImage");
            }
        }
        /*
         * in mass refresh on property change these values
         */
        public void RefreshData()
        {

            OnPropertyChanged("BankrollChipDisplay");
            OnPropertyChanged("SetChipDisplay");
            OnPropertyChanged("ChipStackDisplay");
            OnPropertyChanged("BetActive");
            user.Bankroll = ChipStackDisplay;
        }
        public void RefreshWheel()
        {
            WheelNumber = wheel.number;
        }
        /*
         * chip displays and builds
         */
        public IList<Chip> BankrollChipDisplay
        {
            get
            {
                return BuildChips(user.Bankroll);
            }
        }
        public IList<Chip> SetChipDisplay //3.3.2.4
        {
            get
            {
                return BuildChips(BetSets[BetSetIValue]);
            }
        }
        private IList<Chip> BuildChips(long cash)
        {
            IList<Chip> chips = new List<Chip>();
            foreach (int i in user.ChipDenominations)
            {

                while (cash >= i)
                {
                    chips.Add(new Chip(i));
                    cash -= i;
                }
            }
            return chips;
        }
        /*commands*/
        public ICommand MenuCommand { get; }
        public ICommand BetGenericCommand { get; }
        public ICommand SpinCommand { get; }
        public ICommand SetCommand { get; }

        /*main intializer*/

        public RouletteViewModel(Navigation nav, User user) // (Requirement 3.3.2.1)
        {
            this.user = user;
            this.nav = nav;

            MenuCommand = new MenuCommand(nav, this.user); //3.3.2.2
            BetGenericCommand = new BetGenericCommand(this);
            SpinCommand = new SpinCommand(this);
            SetCommand = new SetCommand(this, this.user);

            ChipStackDisplay = user.Bankroll; //set bankroll 3.3.2.1
            /*
             used to get random value first, so each value
             */
            /*testing is done in the wheel*/
            wheel.getNumber();
            rotateAngle = wheel.degree + 360;
            /*
              intial active bet to 1
            */
            // 3.3.1.1
            ActiveValue = 1.ToString();
            BetSetIValue = 1;

            /*checks bankroll to see if bet is possible  
             Requirement 3.3.1.1
             */
            if (user.Bankroll > 0)
            {
                CanBet = true;
            }

        }



    }
}
