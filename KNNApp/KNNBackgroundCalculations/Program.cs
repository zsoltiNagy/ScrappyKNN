using System;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Adult\adult.csv";
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Wine\Wine.csv";
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Hepatitis\Hepatitis.csv";
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Seeds\SEEDS.csv";

            for (int i = 0; i < 1; i++)
            {
                CsvValidator val = new CsvValidator(path);
                if (val.Result)
                {
                    DataSet reader = new DataSet(path);
                }
                //ScrappyKNN knn = new ScrappyKNN(reader);
                //Console.WriteLine("Accuracy: " + knn.MyAccuracy);
            }
            Console.ReadKey();
        }
    }
}
