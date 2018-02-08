using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KNNBackgroundCalculations
{
    
    /// <summary>
    /// Takes a path to a .csv file as a parameter and makes a dataset from it, shuffles it and creates training data and testing data.
    /// </summary>
    public class DataSet
    {
        public List<Row> MyDataSet { get; private set; }
        public List<Row> TrainingDataset { get; private set; }
        public List<Row> TestingDataset { get; private set; }
        private int classPosition;
        private string filePath;

        public DataSet(string filePath, int classPosition)
        {
            this.classPosition = classPosition;
            MyDataSet = new List<Row>();
            this.filePath = filePath;
            Read();
            CreateTrainingAndTestingData();
        }

        /// <summary>
        /// Shuffles the content of a List.
        /// </summary>
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

        /// <summary>
        /// Creates TrainingDataSet and TestingDataSet from MyDataSet.
        /// </summary>
        private void CreateTrainingAndTestingData()
        {
            TrainingDataset = new List<Row>();
            TestingDataset = new List<Row>();
            // Shuffling the DataSet for more heterogenous training and testing data
            Shuffle(MyDataSet);
            // Splitting the shuffled DataSet by odd and even numbers to add more flavour
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

        /// <summary>
        /// Creates MyDataSet from the file targeted by the filePath.
        /// </summary>
        private void Read()
        {
            // Get the file's text.
            string rawData = File.ReadAllText(filePath);

            // Split into lines.
            rawData = rawData.Replace('\n', '\r');
            rawData = rawData.Replace('\t', ',');
            string[] lines = rawData.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // Load the dataset.
            for (int r = 1; r < lines.Length+1; r++)
            {
                string[] line = lines[r-1].Split(',');
                Row row = new Row(line, classPosition);
                //Flower flower = new Flower(line);
                MyDataSet.Add(row);
            }
        }
    }
}
