using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    /// <summary>
    /// Takes a path to a .csv file as a parameter and makes a dataset from it, shuffles it and creates training data and testing data.
    /// </summary>
    public class DataSet
    {
        public List<Flower> MyDataSet { get; private set; }
        public List<Flower> TrainingDataset { get; private set; }
        public List<Flower> TestingDataset { get; private set; }
        private string filePath;

        public DataSet(string filePath)
        {
            // there should be a method to validate path
            MyDataSet = new List<Flower>();
            this.filePath = filePath;
            Read();
            CreateTrainingAndTestingData();
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void CreateTrainingAndTestingData()
        {
            TrainingDataset = new List<Flower>();
            TestingDataset = new List<Flower>();
            Shuffle(MyDataSet);
            int mid = MyDataSet.Count()/2;
            for (int i = 0; i < MyDataSet.Count(); i++)
            {
                if (i % 2 == 0)
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
