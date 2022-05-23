using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Model.Slots
{
    /// <summary>
    ///         
    //public Card(cardRank rank, cardSuit suit)
    //holds name and string
    // (Requirement 1.2.4)
    /// </summary>
    public class SlotItem
    {

        public SlotName Name;
        public int NameNum;
        public int ColorNum;
        public Color Color;
        public SlotItem(SlotName name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
