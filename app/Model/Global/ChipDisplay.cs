using System.Collections.Generic;


namespace CasinoSimulation.Model.Global
{
    class ChipDisplay
    {
        private long _cash;
        private int[] _chipDenominations;
        private List<Chip> _chips;

        public List<Chip> Chips { 
            get{
                _chips.Clear();
                long tempCash = _cash;
                foreach(int i in _chipDenominations)
                {

                    while(tempCash >= i)
                    {
                        _chips.Add(new Chip(i));
                        tempCash -= i;
                    }
                }
                return _chips;
            } 
        }

        public ChipDisplay(long cash, int[] chipDenominations)
        {
            _cash = cash;
            _chipDenominations = chipDenominations;
            _chips = new List<Chip>();
        }
    }
}
