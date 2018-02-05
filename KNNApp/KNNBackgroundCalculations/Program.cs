using System;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A");
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            for (int i = 0; i < 10; i++)
            {
                DataSet reader = new DataSet(path);
                ScrappyKNN knn = new ScrappyKNN(reader);
                Console.WriteLine("Accuracy: " + knn.MyAccuracy);
            }
            Console.ReadKey();
            
        }
    }
}
