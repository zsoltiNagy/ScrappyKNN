using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KNNBackgroundCalculations;

namespace KNNTests
{
    [TestClass]
    public class DataSetTests
    {
        DataSet reader;

        [TestInitialize()]
        public void Initialize() {
            // Arrange
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            // Act
            string[] columnNames = new string[] { "Sepal Length", "Sepal Width", "Petal Length", "Petal Width", "Species" };
            reader = new DataSet(path, 4, columnNames);
        }


        [TestMethod]
        public void Construct_DataSet_NotNull()
        {
            // Assert
            Assert.IsNotNull(reader);
        }

        [TestMethod]
        public void Read_MyDataSet_NotNull(){
             // Assert
            Assert.IsNotNull(reader.MyDataSet);
        }

        [TestMethod]
        public void CreateTrainingAndTestingData_TrainingDataSet_NotNull()
        {
            // Assert
            Assert.IsNotNull(reader.TrainingDataset);
        }

        [TestMethod]
        public void CreateTrainingAndTestingData_TestingDataSet_NotNull()
        {
            // Assert
            Assert.IsNotNull(reader.TestingDataset);
        }

        [TestMethod]
        public void CreateTrainingAndTestingData_TestingDataSet_TrainingDataSet_EqualLength()
        {
            // Assert
            Assert.AreEqual(reader.TrainingDataset.Count, reader.TestingDataset.Count);
        }
    }
}
