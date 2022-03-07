using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_WineQuality
{
    internal class Wine : IWine
    {
        private float[] _features;
        public float[] Features
        {
            set { _features = value; }
            get { return _features; }
        }

        private int _label;
        public int Label
        {
            set { _label = value; }
            get { return _label; }
        }

        public Wine(List<String> featuresStrings, String quality)
        {
            int n = 0;

            _features = new float[4];
            try
            {
                _label = Int32.Parse(quality);

                foreach (var feature in featuresStrings) {
                    _features[n] = float.Parse(feature);
                    n++;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error in features initialisation");
                throw;
            }
        }

        public void PrintInfo()
        {
            if (_features.Count() == 4) {
                Console.WriteLine("Alcohol\t| Sulphates\t| Citric acid\t| Volatile acidity\t| Quality");
                Console.WriteLine($"{_features[0]}\t| {_features[1]}\t| {_features[2]}\t| {_features[3]}\t| {_label}");
            } else {
                Console.WriteLine("Sorry, features length is incorrect, please check it.");
            }
        }
    }
}
