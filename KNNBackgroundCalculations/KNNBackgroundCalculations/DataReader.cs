using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    class DataReader
    {
        private string filePath;
        public int NumOfRows { get; set; }
        public int NumOfCols { get; set; }
        public Dictionary<int, string> Y_test { get; set; }
        public Dictionary<int, string> Y_train { get; set; }
        public Dictionary<int, double[]> X_test { get; set; }
        public Dictionary<int, double[]> X_train { get; set; }
        public Dictionary<int, double[]> FeatureValues { get; set; }
        public Dictionary<int, string> TargetValues { get; set; }

        public DataReader(string filePath)
        {
            // there should be a method to validate path
            this.filePath = filePath;
            Read();
            SeperateTrainDataAndTestData();
        }

        private void SeperateTrainDataAndTestData()
        {
            // Refactor to use generics
            var ordered = TargetValues.OrderBy(kv => kv.Key);
            var half = TargetValues.Count / 2;
            Y_test = ordered.Take(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            Y_train = ordered.Skip(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            var ordered2 = FeatureValues.OrderBy(kv => kv.Key);
            half = FeatureValues.Count / 2;
            X_test = ordered2.Take(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            X_train = ordered2.Skip(half).ToDictionary(kv => kv.Key, kv => kv.Value);
        }
        
        private void Read()
        {
            // Get the file's text.
            string rawData = File.ReadAllText(filePath);

            // Split into lines.
            rawData = rawData.Replace('\n', '\r');
            string[] lines = rawData.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            NumOfRows = lines.Length;
            NumOfCols = lines[0].Split(',').Length;

            // Set the dictionaries
            FeatureValues = new Dictionary<int, double[]>();
            TargetValues = new Dictionary<int, string>();

            // Fill the dictionaries.
            for (int r = 1; r < NumOfRows+1; r++)
            {
                string[] line = lines[r-1].Split(',');
                double[] lineOfFeatures = new double[NumOfCols - 1];
                for (int c = 0; c < NumOfCols-1; c++)
                {
                    lineOfFeatures[c] = Double.Parse(line[c]);
                }
                FeatureValues.Add(r, lineOfFeatures);
                TargetValues.Add(r, line[line.Length - 1]);
            }
        }
    }
}
