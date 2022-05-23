using System.Resources;
using System.Reflection;

namespace CasinoSimulation.Model.Global
{
    /// <summary>
    /// UI class to hold chip image data and values
    /// </summary>
    public class Chip
    {
        public int Value { get; }
        public byte[] ImageData { get; }
        private ResourceManager _rm;
        private string _resourceName;
        public Chip(int value)
        {
            Value = value;
            _resourceName = Value + "_Flat";
            _rm = new ResourceManager("CasinoSimulation.Properties.Resources", Assembly.GetExecutingAssembly());
            ImageData = (byte[])_rm.GetObject(_resourceName);
        }
    }
}
