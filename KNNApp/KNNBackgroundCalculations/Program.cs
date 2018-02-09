using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] columnNames = new string[] { "Sepal Length", "Sepal Width", "Petal Length", "Petal Width", "Species" };
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv"; //4

            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Adult\adult.csv";

            //string[] columnNames = new string[] {"Type","Aclohol","Malic Acid","Ash","Alcanity of ash","Magnesium","Total phenols",
            //"Flavanoids","Nonflavanoid phenols","Proanthocyanins","Color intensity","Hue","OD280 / OD315 of diluted wines","Proline"};
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Wine\Wine.csv"; //0
            
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Hepatitis\Hepatitis.csv";
            
            string[] columnNames = new string[] {"Area", "Perimeter", "Compactness", "Length of kernel",
            "Width of Kernel", "Asymmetry coefficient", "Length of Kernel groove", "1:Kama,2:Rosa,3:Canadian"};
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Seeds\SEEDS.csv"; //7

            for (int i = 0; i < 10; i++)
            {
                CsvValidator val = new CsvValidator(path);
                if (val.Result)
                {
                    DataSet reader = new DataSet(path, 7, columnNames);
                    ScrappyKNN knn = new ScrappyKNN(reader);
                    Console.WriteLine("Accuracy: " + knn.MyAccuracy);
                    FlexibleKNN fknn = new FlexibleKNN(reader);
                    Console.WriteLine("Flexible Accuracy: " + fknn.MyAccuracy);

                    Console.WriteLine(reader.TrainingTable.Columns[reader.classPosition].Table);
                }
            }
            Console.ReadKey();
        }
    }
}
