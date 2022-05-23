using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CasinoSimulation.Model.Slots
{
    /// <summary>
    /// (Requirement 1.2.4)
    /// build list of slot items that correspond with view
    /// </summary>
    public class SlotLine
    {
        public List<SlotItem> _items;

        public SlotLine()
        {
            _items = new List<SlotItem>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 2)
                    {
                        j = 3;
                    }
                    SlotItem newItem = new SlotItem((SlotName)i, (Color)j);

                    _items.Add(newItem);
                    Debug.WriteLine(i + " " + j + " " + newItem.Color + " " + newItem.Name + " " + _items.Count);
                }
                if (i == 2)
                {
                    break;
                }
            }

        }
    }
}
