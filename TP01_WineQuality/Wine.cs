using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_WineQuality
{
    internal class Wine
    {
        private float[] features;
        float[] Features 
        { 
            set { features = value; }
            get { return features; }
        }

        private int label;
        int Label
        {
            set { label = value; }
            get { return label; }
        }
        void PrintInfo() {
            
        }
    }
}
