using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    /// <summary>
    /// Simple class to contain lines of data from the Iris dataset.
    /// </summary>
    public class Flower
    {
        //sepal_length,sepal_width,petal_length,petal_width,species
        public string Species { get; private set; }
        public double SepalLength { get; private set; }
        public double SepalWidth { get; private set; }
        public double PetalLength { get; private set; }
        public double PetalWidth { get; private set; }
        public double[] Features { get; private set; }

        public Flower(string[] line)
        {
            SepalLength = Double.Parse(line[0]);
            SepalWidth = Double.Parse(line[1]);
            PetalLength = Double.Parse(line[2]);
            PetalWidth = Double.Parse(line[3]);
            Species = line[4];
            FillFeatures();
        }

        private void FillFeatures()
        {
            Features = new double[4];
            Features[0] = SepalLength;
            Features[1] = SepalWidth;
            Features[2] = PetalLength;
            Features[3] = PetalWidth;
        }
    }
}
