using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    public class Flower
    {
        //sepal_length,sepal_width,petal_length,petal_width,species
        public string Species { get; private set; }
        public double SepalLength { get; private set; }
        public double SepalWidth { get; private set; }
        public double PetalLength { get; private set; }
        public double PetalWidth { get; private set; }
        public Flower(string[] line)
        {
            SepalLength = Double.Parse(line[0]);
            SepalWidth = Double.Parse(line[1]);
            PetalLength = Double.Parse(line[2]);
            PetalWidth = Double.Parse(line[3]);
            Species = line[4];
        }
    }
    public class DataReader
    {
        public List<Flower> Dataset { get; set; }
        public List<Flower> TrainingDataset { get; set; }
        public List<Flower> TestingDataset { get; set; }
        private string filePath;

        public DataReader(string filePath)
        {
            // there should be a method to validate path
            Dataset = new List<Flower>();
            this.filePath = filePath;
            Read();
            CreateTrainingAndTestingData();
        }


        private void CreateTrainingAndTestingData()
        {
            TrainingDataset = new List<Flower>();
            TestingDataset = new List<Flower>();
            int mid = Dataset.Count()/2;
            for (int i = 0; i < Dataset.Count(); i++)
            {
                if (i < mid)
                {
                    TrainingDataset.Add(Dataset[i]);
                }
                else
                {
                    TestingDataset.Add(Dataset[i]);
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
                Dataset.Add(flower);
            }
        }
    }
}
