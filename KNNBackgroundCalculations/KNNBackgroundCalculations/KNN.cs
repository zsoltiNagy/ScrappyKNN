using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    abstract class KNN
    {
        int[] x_train;
        int[] y_train;
        abstract public int[] Predict(int[] x_test);
        abstract public int[] Closest(int[] row);        
    }
}
