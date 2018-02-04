using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    public class DataSet
    {
        public List<Flower> MyDataSet { get; set; }
        public List<Flower> TrainingDataset { get; set; }
        public List<Flower> TestingDataset { get; set; }
        private string filePath;

        public DataSet(string filePath)
        {
            // there should be a method to validate path
            MyDataSet = new List<Flower>();
            this.filePath = filePath;
            Read();
            CreateTrainingAndTestingData();
        }


        private void CreateTrainingAndTestingData()
        {
            TrainingDataset = new List<Flower>();
            TestingDataset = new List<Flower>();
            int mid = MyDataSet.Count()/2;
            for (int i = 0; i < MyDataSet.Count(); i++)
            {
                if (i < mid)
                {
                    TrainingDataset.Add(MyDataSet[i]);
                }
                else
                {
                    TestingDataset.Add(MyDataSet[i]);
                }
            }
        }
        
        private void Read()
        {
            // Get the file's text.
            string rawData = File.ReadAllText(filePath);

            // Split into lines.
            rawData = rawData.Replace('\n', '\r');
            string[] lines = rawData.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // Load the dataset.
            for (int r = 1; r < lines.Length+1; r++)
            {
                string[] line = lines[r-1].Split(',');
                Flower flower = new Flower(line);
                MyDataSet.Add(flower);
            }
        }
    }
}
