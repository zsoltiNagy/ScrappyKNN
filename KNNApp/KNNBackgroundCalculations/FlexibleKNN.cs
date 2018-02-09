using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    public class FlexibleKNN : KNN
    {
        private DataSet DataSet { get; }
        protected override List<string> Predictions { get; set; }
        public override double MyAccuracy { get; }
        public int RowLength { get; set; }

        public FlexibleKNN(DataSet dataSet)
        {
            DataSet = dataSet;
            Predict();
            MyAccuracy = Accuracy();
            RowLength = DataSet.TestingTable.Rows[0].ItemArray.Length;

        }

        private double[] GetRowDoubleArray(DataRow dataRow)
        {
            int rowLength = DataSet.TestingTable.Rows[0].ItemArray.Length;
            double[] row = new double[rowLength-1];
            for (int cell = 0; cell < rowLength; cell++)
            {
                if (cell > DataSet.classPosition)
                {
                    row[cell - 1] = (double)dataRow.ItemArray[cell];
                }
                else if (cell < DataSet.classPosition)
                {
                    row[cell] = (double)dataRow.ItemArray[cell];
                }
            }
            return row;
        }

        protected override void Predict()
        {
            Predictions = new List<string>();
            foreach (DataRow dataRow in DataSet.TestingTable.Rows)
            {
                double[] row = GetRowDoubleArray(dataRow);
                string label = Closest(row);
                Predictions.Add(label);
            }
        }

        protected string Closest(double[] testRow)
        {
            int rowLength = DataSet.TestingTable.Rows[0].ItemArray.Length;
            double[] baseTrainRow = GetRowDoubleArray(DataSet.TrainingTable.Rows[0]);

            double bestDistance = EucledianDistance(testRow, baseTrainRow);
            int bestIndex = 0;

            double distance;
            double[] trainRow = new double[rowLength];
            for (int i = 1; i < DataSet.TrainingTable.Rows.Count; i++)
            {
                trainRow = GetRowDoubleArray(DataSet.TrainingTable.Rows[i]);

                distance = EucledianDistance(testRow, trainRow);

                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestIndex = i;
                }
            }
            var x = DataSet.TrainingTable.Rows[bestIndex].ItemArray[DataSet.classPosition];
            return x.ToString();
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

        protected override double Accuracy()
        {
            List<string> actual = new List<string>();
            foreach (DataRow dataRow in DataSet.TestingTable.Rows)
            {
                var x = dataRow.ItemArray[DataSet.classPosition];
                actual.Add(x.ToString());
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
