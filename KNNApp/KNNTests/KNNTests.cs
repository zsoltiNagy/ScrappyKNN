using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KNNBackgroundCalculations;

namespace KNNTests
{
    //[TestClass]
    public class KNNTests
    {
        [TestMethod]
        public void Construct_KNN_DatasetNotNull()
        {
            // Arrange
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            DataSet dataset = new DataSet(path, 4);

            // Act
            ScrappyKNN knn = new ScrappyKNN(dataset);

            // Assert
            //Assert.IsNotNull(knn.Dataset);
        }

        [TestMethod]
        public void Predict_Predictions_NotNull()
        {
            // Arrange
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            DataSet dataset = new DataSet(path, 4);
            ScrappyKNN knn = new ScrappyKNN(dataset);

            // Act
            //knn.Predict();

            // Assert
            //Assert.IsNotNull(knn.Predictions);
        }

        [TestMethod]
        public void Predict_Predictions_CountEqualsTestingDataSetCount()
        {
            // Arrange
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            DataSet dataset = new DataSet(path, 4);
            ScrappyKNN knn = new ScrappyKNN(dataset);

            // Act
            //knn.Predict();

            // Assert
            //Assert.IsTrue(knn.Predictions.Count == dataset.TestingDataset.Count);
        }
    }
}
