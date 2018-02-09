using System;
using System.Collections.Generic;
using System.Linq;

namespace KNNBackgroundCalculations
{
    public class Row
    {
        public string Class { get; private set; }
        public double[] Features { get; private set; }
        public Dictionary<int, object> Data { get; private set; }

        public Row(string[] line, int classPosition)
        {
            Dictionary<int, object> Data = new Dictionary<int, object>();
            for (int i = 0; i < line.Length; i++)
            {
                if (Double.TryParse(line[i], out double number)){
                    Data.Add(i, number);
                } else
                {
                    Data.Add(i, line[i]);
                }
            }

            Class = line[classPosition];
            Features = new double[line.Length - 1];

            var lineList = line.ToList();
            lineList.Remove(lineList[classPosition]);

            for (int i=0; i < lineList.Count; i++)
            {
                Features[i] = Double.Parse(lineList[i]);
            }
        }

        public override string ToString()
        {

            return "AAA";
        }
    }
}
