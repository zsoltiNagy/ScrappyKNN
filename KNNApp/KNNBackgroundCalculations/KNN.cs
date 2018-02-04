using System;
using System.Collections.Generic;


namespace KNNBackgroundCalculations
{
    public abstract class KNN
    {
        public abstract List<string> Predictions { get; set; }
        abstract public void Predict();
        abstract public string Closest(double[] row);        
    }

    public class ScrappyKNN : KNN
    {
        public DataSet Dataset { get; private set; }
        public override List<string> Predictions { get; set; }
        public double MyAccuracy;

        public ScrappyKNN(DataSet dataset)
        {
            this.Dataset = dataset;
            Predict();
            MyAccuracy = Accuracy();
        }

        public override void Predict()
        {
            Predictions = new List<string>();
            double[] row = new double[4];
            foreach (var flower in Dataset.TestingDataset)
            {
                row = flower.Features;
                string label = Closest(row);
                Predictions.Add(label);
            }
        }

        public override string Closest(double[] testFlower)
        {
            double[] baseTrainFlower = Dataset.TrainingDataset[0].Features;

            double bestDistance = EucledianDistance(testFlower, baseTrainFlower);
            int bestIndex = 0;

            double distance;
            double[] trainFlower = new double[4];
            for (int i = 1; i < Dataset.TrainingDataset.Count; i++)
            {
                // update trainFlower
                trainFlower = Dataset.TrainingDataset[i].Features;

                distance = EucledianDistance(testFlower, trainFlower);
            
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestIndex = i;
                }                
            }
            return Dataset.TrainingDataset[bestIndex].Species;
        }

        private double EucledianDistance(double[] test, double[] train)
        {
            if (train.Length != test.Length)
            {
                throw new ArgumentException("Training and testing row was not equal.");
            }

            double distance = 0;
            for (int i = 0; i < test.Length; i++)
            {
                distance += (test[i] - train[i]) * (test[i] - train[i]);
            }

            return Math.Sqrt(distance);
        }

        public double Accuracy()
        {
            List<string> actual = new List<string>();
            foreach (var flower in Dataset.TestingDataset)
            {
                actual.Add(flower.Species);
            }

            double accuracy = 0;

            for (int p = 0; p < Predictions.Count; p++)
            {
                if (Predictions[p].Equals(actual[p]))
                {
                    accuracy += 1;
                }
            }
            accuracy = (accuracy / Predictions.Count) * 100;
            
            return accuracy;
        }
    }
}
