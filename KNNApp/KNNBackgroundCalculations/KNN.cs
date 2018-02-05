using System;
using System.Collections.Generic;


namespace KNNBackgroundCalculations
{
    /// <summary>
    /// Base for all k-nearest neighbors algorithm implementations.
    /// </summary>
    public abstract class KNN
    {
        protected abstract List<string> Predictions { get; set; }
        abstract protected void Predict();
        abstract protected string Closest(double[] row);        
    }

    /// <summary>
    /// A very basic k-nearest neighbors algorithm. Needs a DataSet type as parameter to construct.
    /// </summary>
    public class ScrappyKNN : KNN
    {

        private DataSet Dataset { get; }
        protected override List<string> Predictions { get; set; }
        public double MyAccuracy;

        public ScrappyKNN(DataSet dataset)
        {
            this.Dataset = dataset;
            Predict();
            MyAccuracy = Accuracy();
        }

        /// <summary>
        /// Iterates through the TestingDataset, calls the Closest method on every row, then puts the results in the Predictions list.
        /// </summary>
        protected override void Predict()
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

        /// <summary>
        /// Takes a row of testing data and predicts its class by finding the closest row with the least EucledianDistance result.
        /// </summary>
        /// <param name="testFlower">A row of test data.</param>
        /// <returns>String representing the predicted class.</returns>
        protected override string Closest(double[] testFlower)
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

        /// <summary>
        /// Calculates the eucledian distance between two rows of data.
        /// </summary>
        /// <param name="test">A row of data from the TestingDataset</param>
        /// <param name="train">A row of data from the TrainingDataset</param>
        /// <returns></returns>
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

        /// <summary>
        /// Compares the predicted classes with the actual ones.
        /// </summary>
        /// <returns>Give back a double, that is representing the accuracy percent of the current run.</returns>
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
