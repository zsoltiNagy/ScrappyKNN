using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNAppGUI
{
    class DataReader
    {
        int[] data;
        DataReader(string filePath)
        {
            data = Read(filePath);
        }

        private int[] Read(string filePath)
        {
            int[] j = new int[0];
            return j;
        }
    }
}
