using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Text;
using CasinoSimulation.Command.Slots;
using CasinoSimulation.Model.Slots;

namespace CasinoSimulation.ViewModel
{
    public class SlotViewModel : ViewModelBase
    {
        /// <summary>
        /// 2.1
        /// </summary>
        public const int DELAY_MILLISECONDS = 10000;
        /*the has spun value checks to see if it has spun, this is use to reset the credits back to lower numbers if wanted or
         * or to allow the player to hit spin at the begining and for them to bet max
         */
        public bool HasSpun = false; //
        //holder for the lines object: slots
        public lines Llines = new lines();

        /// <summary>
        /// property change items
        /// </summary>

        //_slts can be removed they tell more cleanly what is on screen
        public string _slt1 = "0";
        public string _slt2 = "0";
        public string _slt3 = "0";
        //tell user how many coins have been played
        public int _CoinsPlayed = 0; //3.4.1.1
        //tell user how much has been paid out to users
        public int _PaidAmount = 0;
        //credits are user bankroll 3.4.1.1.5
        public long _Credits;

        User _user; // main connection

        public int _tableOpacity = 0; // disable or enable table

        //random values given to lanes, the lanes themselves are used as y-axis location holders for each lane
        public int _Leftline = -5100;
        public int _Rightline = -2220;
        public int _Midline = -2220;
        //holds the actual slot objects for each slot line
        public SlotLine line1 = new SlotLine();
        public SlotLine line2 = new SlotLine();
        public SlotLine line3 = new SlotLine();
        //commands
        public ICommand MenuCommand { get; }
        public ICommand SpinSlotsCommand { get; }
        public lines locations = new lines();
        public ICommand BetSlotCommand { get; }
        public ICommand BetTableCommand { get; }
        // slot view model intializer (Requirement 3.4.2.1)
        public SlotViewModel(Navigation nav, User user)
        {
            // commands
            //3.4.2.4
            MenuCommand = new MenuCommand(nav, user);
            SpinSlotsCommand = new SpinSlotsCommand(this);
            /*3.4.2.2*/
            BetSlotCommand = new BetSlotCommand(this, user);
            //3.4.2.5
            BetTableCommand = new BetTableCommand(this, user);

            // credits display becomes that of bankroll
            _Credits = user.Bankroll; //3.4.2.1
            // locations of y-axis, while it is stored in lines this is used to help in the begining
            int[] locations = new int[] { -2770, -3160, -3560, -3945, -4345, -4735, -5135 };
            // Random Values generated for each slot 3.4.2.1
            Random r = new Random();
            int rholder = r.Next(7);
            Llines.line1 = rholder;
            Leftline = locations[rholder];
            rholder = r.Next(7);
            Llines.line2 = rholder;
            Midline = locations[rholder];
            rholder = r.Next(7);
            Llines.line3 = rholder;
            Rightline = locations[rholder];

            /*          
            int rholder = 1;
            Llines.line1 = rholder;
            Leftline = locations[rholder];
            rholder = 2;
            Llines.line2 = rholder;
            Midline = locations[rholder];
            rholder = 3;
            Llines.line3 = rholder;
            Rightline = locations[rholder];
             */

            _user = user;
        }
        /*
         property changed methods
         */
        public long Credits //3.4.1.1.5
        {
            get
            {
                return _Credits;
            }
            set
            {
                _Credits = value;
                _user.Bankroll = _Credits;
                OnPropertyChanged("Credits");
            }
        }
        public int tableOpacity
        {
            get
            {
                return _tableOpacity;
            }
            set
            {
                _tableOpacity = value;
                OnPropertyChanged("tableOpacity");
            }
        }
        public int Leftline
        {
            get
            {
                return _Leftline;
            }
            set
            {
                _Leftline = value;
                OnPropertyChanged("Leftline");
            }
        }
        public int Rightline
        {
            get
            {
                return _Rightline;
            }
            set
            {
                _Rightline = value;
                OnPropertyChanged("Rightline");
            }
        }
        public int Midline
        {
            get
            {
                return _Midline;
            }
            set
            {
                _Midline = value;
                OnPropertyChanged("Midline");
            }
        }
        public int PaidAmount
        {
            get
            {
                return _PaidAmount;
            }
            set
            {
                _PaidAmount = value;
                OnPropertyChanged("PaidAmount");
            }
        }
        public int CoinsPlayed
        {
            get
            {
                return _CoinsPlayed;
            }
            set
            {
                _CoinsPlayed = value;
                OnPropertyChanged("CoinsPlayed");
            }
        }
        public string slt1
        {
            get
            {
                return _slt1;
            }
            set
            {
                _slt1 = value;
                OnPropertyChanged("slt1");
            }
        }
        public string slt2
        {
            get
            {
                return _slt2;
            }
            set
            {
                _slt2 = value;
                OnPropertyChanged("slt2");
            }
        }
        public string slt3
        {
            get
            {
                return _slt3;
            }
            set
            {
                _slt3 = value;
                OnPropertyChanged("slt3");
            }
        }
    }
}
