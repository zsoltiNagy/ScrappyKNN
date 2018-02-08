using System;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv"; //4
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Adult\adult.csv";
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Wine\Wine.csv"; //0
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Hepatitis\Hepatitis.csv";
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Seeds\SEEDS.csv"; //7

            for (int i = 0; i < 10; i++)
            {
                CsvValidator val = new CsvValidator(path);
                if (val.Result)
                {
                    DataSet reader = new DataSet(path, 7);
                    ScrappyKNN knn = new ScrappyKNN(reader);
                    Console.WriteLine("Accuracy: " + knn.MyAccuracy);
                }
            }
            Console.ReadKey();
        }
    }
}
